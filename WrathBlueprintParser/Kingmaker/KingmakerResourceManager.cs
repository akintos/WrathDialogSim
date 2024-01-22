using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SharpCompress.Archives.Zip;
using System.Reflection;
using WrathBlueprintParser;

namespace Kingmaker;

public class KingmakerResourceManager
{
    private static KingmakerResourceManager _instance;

    public string GameDirectory { get; set; }

    internal JsonSerializer Serializer { get; set; }

    internal readonly Dictionary<Guid, SimpleBlueprint> BlueprintDict = new();
    internal readonly Dictionary<Guid, string> AssetNameDict = new();

    internal Dictionary<string, string> GuidTypenameDict;

    internal readonly HashSet<string> MissingClassNames = new();
    internal readonly HashSet<string> MissingFieldNames = new();

    internal Dictionary<string, string> LocaleData = new();

    internal Dictionary<string, string> SpawnerUnitData = new();

    internal JbpCatalog BlueprintCatalog;

    public static KingmakerResourceManager Instance => _instance ??= new KingmakerResourceManager();

    private KingmakerResourceManager()
    {

    }

    public void Initialize(string gameDirectory)
    {
        GameDirectory = gameDirectory;

        string txt = File.ReadAllText(Program.GetDataFilePath("typeguid.json"));
        GuidTypenameDict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(txt);

        JsonSerializerSettings settings = new()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            Error = IgnoreMissingTypeErrorHandler,
            // MissingMemberHandling = MissingMemberHandling.Error,
            SerializationBinder = new GuidTypeBinder(GuidTypenameDict),
        };

        Serializer = JsonSerializer.Create(settings);

        LoadLocale();

        string zipPath = Path.Combine(gameDirectory, "blueprints.zip");
        BlueprintCatalog = JbpCatalog.LoadOrCreate(zipPath, GuidTypenameDict);

        string bundlesDir = Path.Combine(gameDirectory, "bundles");
        SpawnerUnitData = SpawnerDataExtractor.GetData(bundlesDir);
    }

    public void LoadLocale(string lang = "enGB")
    {
        string jsonPath = Path.Combine(GameDirectory, "Wrath_Data", "StreamingAssets", "Localization", $"{lang}.json");

        using Stream stream = File.OpenRead(jsonPath);
        LocaleData = System.Text.Json.JsonSerializer.Deserialize<Locale>(stream).strings;
    }

    public SimpleBlueprint GetBlueprint(BlueprintReferenceBase bpRef)
    {
        return BlueprintDict[bpRef.Guid];
    }

    public SimpleBlueprint GetBlueprint(string guid)
    {
        return BlueprintDict[new Guid(guid)];
    }

    public SimpleBlueprint GetBlueprint(Guid guid)
    {
        if (BlueprintDict.ContainsKey(guid))
            return BlueprintDict[guid];
        return null;
    }

    public string GetTranslation(string key)
    {
        if (LocaleData.ContainsKey(key))
            return LocaleData[key];
        return null;
    }

    public string GetBlueprintName(Guid guid)
    {
        if (BlueprintCatalog.TryGetValue(guid.ToString("N"), out var entry))
            return entry.Name;
        return null;
    }

    public void LoadJbpZipFile(Func<string, bool> filter = null)
    {
        string zipPath = Path.Combine(GameDirectory, "blueprints.zip");
        using ZipArchive zipFile = ZipArchive.Open(zipPath);

        Console.WriteLine($"Loading blueprint zip file...");
        Console.WriteLine($"Path : {zipPath}");

        List<ZipArchiveEntry> files;
        files = zipFile.Entries.Where(x => x.Key.EndsWith(".jbp")).ToList();

        if (filter != null)
        {
            HashSet<string> paths = BlueprintCatalog.Values
                .Where(x => filter(GuidTypenameDict[x.TypeGuid]))
                .Select(x => x.Path)
                .ToHashSet();
            files = files.Where(x => paths.Contains(x.Key)).ToList();
        }

        for (int i = 0; i < files.Count; i++)
        {
            Console.Write($"Loading blueprint {i} / {files.Count}\r");
            var entry = files[i];

            string filename = Path.GetFileNameWithoutExtension(entry.Key);
            JbpAsset jbp;

            using (Stream stream = entry.OpenEntryStream())
            using (StreamReader streamReader = new(stream))
            using (JsonTextReader jsonReader = new(streamReader))
            {
                jbp = Serializer.Deserialize<JbpAsset>(jsonReader);
            }

            if (jbp?.Data is null)
            {
                continue;
            }

            SimpleBlueprint bp = jbp.Data;

            bp.Name = filename;
            bp.Guid = jbp.AssetId;
            bp.Path = entry.Key[..(entry.Key.Length - 4)];

            BlueprintDict.Add(new Guid(jbp.AssetId), bp);
        }

        Console.WriteLine("\nFinished loading jbp zip file.");
    }

    public string GetNameFromUnitEvaluator(UnitEvaluator evaluator)
    {
        if (evaluator is CompanionInParty companionInParty)
        {
            return companionInParty.m_Companion.Get().LocalizedName.Get();
        }
        else if (evaluator is UnitFromSpawner unitFromSpawner)
        {
            if (SpawnerUnitData.TryGetValue(unitFromSpawner.Spawner.UniqueId, out string unitGuid))
            {
                BlueprintUnit unit = (BlueprintUnit)KingmakerResourceManager.Instance.GetBlueprint(unitGuid);
                return unit.LocalizedName.Get();
            }
            else
            {
                return unitFromSpawner.Spawner.EntityNameInEditor;
            }
        }
        else if (evaluator is FirstUnitFromSummonPool firstUnitFromSummonPool)
        {
            string summonPoolName = firstUnitFromSummonPool.m_SummonPool.Name;

            return summonPoolName switch
            {
                "PlayerFormThePast" => "Player from the past",
                "MythicLich_DeadStaunton" => "Staunton Vhane",
                "Ziggurat_Zacharius" => "Zacharius",
                "LannQ1_LannNotCompanion" => "Lann",
                "NPC_Elyanka" => "Elyanka",
                "KyadoPool" => "Kyado",
                "HeraldSecondPhase" => "Herald",
                "AreeluVorleshPool" => "Areelu Vorlesh",
                "Threshold_LegendShadowCutscene"=> "Shadow",
                "DLC1_ShamiraAmbush_Yozz" => "Yozz",
                "RunningSoldiers" => "Soldier",
                "LannQ1_WenduagNotCompanion" => "Wenduag",
                _ => summonPoolName
            };
        }
        else if (evaluator is PetEvaluator pet && pet.PetType == PetType.AzataHavocDragon)
        {
            return "Aivu";
        }
        else if (evaluator is DialogCurrentSpeaker || evaluator is ConditionalUnitEvaluator || evaluator is ClickedUnit)
        {
            return null;
        }
        else
        {
            return evaluator.ToString();
        }
    }

    private void IgnoreMissingTypeErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
    {
        string msg = args.ErrorContext.Error.Message;

        /// Error resolving type specified in JSON 'Kingmaker.Designers.EventConditionActionSystem.Actions.ToggleObjectFx, Assembly-CSharp'.
        /// Path 'OnSelect.Actions[0].IfTrue.Actions[0].$type', line 58, position 111.
        if (msg.StartsWith("Error resolving type specified in JSON") || msg.StartsWith("Type specified in JSON"))
        {
            int startpos = msg.IndexOf('\'') + 1;
            int endpos = msg.IndexOf(',');
            string classname = msg[startpos..endpos];
            MissingClassNames.Add(GuidTypenameDict[classname]);

            args.ErrorContext.Handled = true;
        }
        // Could not find member 'PrototypeLink' on object of type 'BlueprintAnswersList'. Path 'PrototypeLink', line 11, position 18.
        else if (msg.StartsWith("Could not find member"))
        {
            string[] parts = msg.Split('\'');
            string fieldName = parts[1];
            string className = parts[3];

            MissingFieldNames.Add($"{className}/{fieldName}");

            args.ErrorContext.Handled = true;
        }
    }

    public class GuidTypeBinder : DefaultSerializationBinder
    {
        private readonly Dictionary<string, string> guidTypeMap;

        private readonly Dictionary<string, Type> TypeCache = new();

        public GuidTypeBinder(Dictionary<string, string> guidTypeMap) : base()
        {
            this.guidTypeMap = guidTypeMap;

            var thisAssembly = Assembly.GetAssembly(typeof(GuidTypeBinder));
            foreach (var type in thisAssembly.GetTypes())
            {
                TypeCache[type.FullName] = type;
                // TypeCache[type.Name] = type;
            }
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            Type result;

            string actualTypeName;

            if (Guid.TryParse(typeName, out _) && guidTypeMap.TryGetValue(typeName, out actualTypeName))
            {
                
            }
            else
            {
                actualTypeName = typeName;
            }

            if (TypeCache.TryGetValue(typeName, out result))
                return result;

            if (assemblyName == "Assembly-CSharp")
                return null;

            result = base.BindToType(Assembly.GetExecutingAssembly().GetName().Name, actualTypeName);
            TypeCache[typeName] = result;

            return result;
        }
    }
}
