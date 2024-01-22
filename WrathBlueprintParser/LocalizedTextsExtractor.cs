using AssetsTools.NET;
using AssetsTools.NET.Extra;
using Kingmaker.AreaLogic.Cutscenes.Commands;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharpCompress.Archives.Zip;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace WrathBlueprintParser;
internal class LocalizedTextsExtractor : IDisposable
{
    public string GameRoot { get; init; }

    public Dictionary<string, string> GuidTypenameDict;

    private AssetsManager mgr = new();
    private BundleFileInstance bundle;
    private AssetsFileInstance assets;

    private readonly Dictionary<string, ReferencedAssetItem> referencedAssetsMapping;

    private List<LocalizedTextItem> result = new();

    private string ownerPath = "";
    private string ownerString = "";
    private string ownerType = "";

    public LocalizedTextsExtractor(string gameRoot, Dictionary<string, string> guidTypenameDict)
    {
        GameRoot = gameRoot;

        GuidTypenameDict = guidTypenameDict;

        bundle = mgr.LoadBundleFile(Path.Combine(GameRoot, "bundles", "blueprint.assets"));
        assets = mgr.LoadAssetsFileFromBundle(bundle, 0);
        assets.file.GenerateQuickLookupTree();

        mgr.LoadClassPackage("classdata.tpk");
        mgr.LoadClassDatabaseFromPackage(assets.file.Metadata.UnityVersion);

        referencedAssetsMapping = GetReferencedAssetsMapping();
        // DeserializeAll();
    }

    public void ExportJson(string path)
    {
        Console.WriteLine("Exporting localized texts...");

        Dictionary<string, List<LocalizedTextItem>> groupped = result.GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.ToList());

        WrathDialogLib.JsonHelper.SerializeJsonAsync(path, groupped).GetAwaiter().GetResult();
    }

    private void RegisterString(string key, string path, bool shared)
    {
        if (key == "") return;

        path = path.TrimStart('/').Replace("/Entries", "");

        result.Add(new LocalizedTextItem() {
            Key = key, 
            OwnerPath = ownerPath,
            OwnerString = ownerString,
            OnwerType = ownerType,
            OwnerPropertyPath = path,
            Shared = shared,
        });
    }

    private void RegisterAssetLocalizedString(JObject locstr, string path)
    {
        bool shared = false;
        string key = locstr["m_Key"].Value<string>();

        if (key == "" && locstr["Shared"] is JObject sharedObj && sharedObj["stringkey"] != null)
        {
            key = locstr["Shared"]["stringkey"].Value<string>();
            shared = true;
        }

        if (string.IsNullOrEmpty(key))
        {
            JToken sharedToken = locstr["Shared"];

            if ((sharedToken as JValue)?.Value is null)
            {
                return;
            }

            sharedObj = sharedToken as JObject;

            if (sharedObj.ContainsKey("assetguid")) // jbp
            {
                return;
            }

            long sharedFileId = sharedObj["m_FileID"].Value<long>();
            long sharedPathId = sharedObj["m_PathID"].Value<long>();

            if (key == "" && sharedFileId == 0 && sharedPathId == 0)
            {
                return;
            }

            if (sharedFileId == 0)
            {
                JObject sharedAsset = DeserializeAsset(sharedPathId);
                key = sharedAsset["String"]["m_Key"].Value<string>();

                if (key == "")
                {
                    return;
                }
            }
            else
            {
                throw new Exception();
            }

            shared = true;
        }

        RegisterString(key, path, shared);
    }

    private void RegisterJbpLocalizedString(LocalizedString locstr, string path)
    {
        RegisterString(locstr.Key, path, locstr.Shared is not null);
    }

    public void ExtractAll()
    {
        Console.WriteLine("Extracting localized texts...");

        string zipPath = Path.Combine(GameRoot, "blueprints.zip");
        using ZipArchive zipFile = ZipArchive.Open(zipPath);

        var jbpFileList = zipFile.Entries.Where(x => x.Key.EndsWith(".jbp")).ToList();

        for (int i = 0; i < jbpFileList.Count; i++)
        {
            Console.Write($"Loading jbp {i+1} / {jbpFileList.Count}\r");

            ZipArchiveEntry entry = jbpFileList[i];
            using Stream stream = entry.OpenEntryStream();
            using StreamReader streamReader = new(stream);
            using JsonTextReader jsonReader = new(streamReader);

            JObject jbp = JToken.Load(jsonReader) as JObject;

            ownerPath = entry.Key[..(entry.Key.Length - 4)];
            ownerString = jbp["AssetId"].Value<string>();

            string typeGuid = jbp["Data"]["$type"].Value<string>()[..32];

            if (GuidTypenameDict.TryGetValue(typeGuid, out string typename))
            {
                ownerType = typename;
            }
            else
            {
                ownerType = "UNKNOWN_TYPE";
            }

            Traverse(jbp["Data"], "");
        }
    }

    public void ExtractAsset(string guid, string path)
    {
        if (!referencedAssetsMapping.TryGetValue(guid, out ReferencedAssetItem item))
        {
            return;
        }

        if (item.AssetFileID != 0)
        {
            return;
        }

        JObject asset = DeserializeAsset(item.AssetPathID);
        Traverse(asset, path + "/" + asset["m_Name"].Value<string>());
    }

    public void ExtractAsset(long pathId, string path)
    {
        if (assets.file.GetAssetInfo(pathId)?.TypeId != (int)AssetClassID.MonoBehaviour)
        {
            return;
        }

        JObject asset = DeserializeAsset(pathId);
        Traverse(asset, path + "/" + asset["m_Name"].Value<string>());
    }

    private void Traverse(JToken token, string path)
    {
        if (token is JArray jarr)
        {
            for (int i = 0; i < jarr.Count; i++)
            {
                Traverse(jarr[i], $"{path}[{i}]");
            }
            return;
        }

        if (token is not JObject jobj)
        {
            return;
        }

        if (jobj.Count == 1 
            && jobj.Children().First() is JProperty jprop 
            && jprop.Name == "Array" 
            && jprop.Value is JArray proparr)
        {
            Traverse(proparr, path);
            return;
        }

        if (jobj.Count == 2)
        {
            if (jobj.ContainsKey("m_Key") && jobj.ContainsKey("Shared"))
            {
                RegisterAssetLocalizedString(jobj, path);
                return;
            }
            else if (jobj.ContainsKey("guid") && jobj.ContainsKey("fileid"))
            {
                string guid = jobj["guid"].Value<string>();
                ExtractAsset(guid, path);
                return;
            }
            else if (jobj.ContainsKey("assetguid") && jobj.ContainsKey("stringkey"))
            {
                RegisterString(jobj["stringkey"].Value<string>(), path, false);
                return;
            }
            else if (jobj.ContainsKey("m_FileID") && jobj.ContainsKey("m_PathID"))
            {
                if (jobj["m_FileID"].Value<long>() != 0) return;
                ExtractAsset(jobj["m_PathID"].Value<long>(), path);
                return;
            }
        }

        if (jobj.Count >= 5
            && jobj.ContainsKey("m_Key")
            && jobj.ContainsKey("m_OwnerString")
            && jobj.ContainsKey("m_OwnerPropertyPath")
            && jobj.ContainsKey("m_JsonPath")
            && jobj.ContainsKey("Shared"))
        {
            LocalizedString locstr = jobj.ToObject<LocalizedString>();
            RegisterJbpLocalizedString(locstr, path);
            return;
        }

        foreach (JToken child in jobj.Children())
        {
            JProperty childprop = child as JProperty;
            JToken childToken = childprop.Value;

            string nextPath = path == "" ? childprop.Name : path + "/" + childprop.Name;

            if (childprop.Name == "$type")
            {
                string typeStr = childToken.Value<string>(); // "507aef8c6c6218c49aaf0987b355f400, PlayCutscene"

                ExtractDialogSpeaker(typeStr, jobj);
            }

            Traverse(childToken, nextPath);
        }
    }

    public Dictionary<Guid, string> DialogSpeakerDict = new();

    private void AddDialogSpeaker(Guid dialogGuid, string speakerName)
    {
        if (DialogSpeakerDict.TryGetValue(dialogGuid, out string prevName))
        {
            if (speakerName != prevName)
            {
                DialogSpeakerDict[dialogGuid] = null;
            }
        }
        else
        {
            DialogSpeakerDict[dialogGuid] = speakerName;
        }
    }

    private void ExtractDialogSpeaker(string typeStr, JObject jobj)
    {
        string typeGuid = typeStr[..32];
        string typeName = typeStr[34..];

        if (typeName == "PlayCutscene")
        {
            PlayCutscene cutscene = jobj.ToObject<PlayCutscene>(KingmakerResourceManager.Instance.Serializer);
            var dialog = cutscene.Parameters?.Parameters?.FirstOrDefault(x => x.Name == "Dialog" || x.Name == "Dialogue");
            var unit = cutscene.Parameters?.Parameters?.FirstOrDefault(x => x.Name == "Unit" || x.Name == "Speaker");

            if (dialog is not null && unit is not null)
            {
                Guid dialogGuid = (dialog.Evaluator as Dialog).m_Value.Guid;
                string speaker = KingmakerResourceManager.Instance.GetNameFromUnitEvaluator(unit.Evaluator as UnitEvaluator);

                AddDialogSpeaker(dialogGuid, speaker);
            }
        }
        else if (typeName == "StartDialog")
        {
            StartDialog startDialog = jobj.ToObject<StartDialog>(KingmakerResourceManager.Instance.Serializer);

            Guid dialogGuid;
            if (startDialog.m_Dialogue is not null)
            {
                dialogGuid = startDialog.m_Dialogue.Guid;
            }
            else if (startDialog.DialogEvaluator is Dialog dialogRef)
            {
                dialogGuid = dialogRef.m_Value.Guid;
            }
            else if (startDialog.DialogEvaluator is NamedParameterBlueprint)
            {
                return;
            }
            else if (startDialog.DialogEvaluator is null)
            {
                return;
            }
            else
            {
                throw new Exception("Unknown dialog type");
            }

            string speaker;
            if (!startDialog.SpeakerName.IsEmptyKey && !string.IsNullOrEmpty(startDialog.SpeakerName.Value))
            {
                speaker = startDialog.SpeakerName.Value;
            }
            else if (startDialog.DialogueOwner is not null)
            {
                speaker = KingmakerResourceManager.Instance.GetNameFromUnitEvaluator(startDialog.DialogueOwner);
            }
            else
            {
                return;
            }

            if (speaker is null)
            {
                return;
            }

            AddDialogSpeaker(dialogGuid, speaker);
        }
        else if (typeName == "CommandStartDialog")
        {
            CommandStartDialog commandStartDialog = jobj.ToObject<CommandStartDialog>(KingmakerResourceManager.Instance.Serializer);

            if (commandStartDialog.Speaker is null)
            {
                return;
            }

            var speaker = KingmakerResourceManager.Instance.GetNameFromUnitEvaluator(commandStartDialog.Speaker);

            if (commandStartDialog.DialogEvaluator is not null && commandStartDialog.DialogEvaluator is not NamedParameterBlueprint)
            {
                if (commandStartDialog.DialogEvaluator is Dialog dialog)
                {
                    AddDialogSpeaker(dialog.m_Value.Guid, speaker);
                }
            }
            else if (commandStartDialog.m_Dialog is not null)
            {
                AddDialogSpeaker(commandStartDialog.m_Dialog.Guid, speaker);
            }
        }
        else if (typeName == "EtudeBracketOverrideDialog")
        {
            JObject etudeBracketOverrideDialog = jobj;

            UnitEvaluator unit = etudeBracketOverrideDialog["Unit"]?.ToObject<UnitEvaluator>(KingmakerResourceManager.Instance.Serializer);
            BlueprintDialogReference dialogRef = etudeBracketOverrideDialog["Dialog"]?.ToObject<BlueprintDialogReference>(KingmakerResourceManager.Instance.Serializer);

            string speaker = KingmakerResourceManager.Instance.GetNameFromUnitEvaluator(unit);

            AddDialogSpeaker(dialogRef.Guid, speaker);
        }
    }

    private Dictionary<string, JObject> blueprintCache = new();
    private Dictionary<long, JObject> deserializationCache = new();

    private JObject DeserializeAsset(long pathId)
    {
        if (deserializationCache.TryGetValue(pathId, out JObject result))
        {
            return result;
        }

        AssetFileInfo info = assets.file.GetAssetInfo(pathId);
        return DeserializeAsset(info);
    }

    private JObject DeserializeAsset(AssetFileInfo info)
    {
        AssetTypeValueField baseField = mgr.GetBaseField(assets, info, AssetReadFlags.None);
        JObject jBaseField = RecurseJsonDump(baseField, false) as JObject;
        deserializationCache[info.PathId] = jBaseField;
        if (jBaseField.ContainsKey("AssetId"))
        {
            blueprintCache[jBaseField["AssetId"].Value<string>()] = jBaseField;
        }
        return jBaseField;
    }

    private Dictionary<string, ReferencedAssetItem> GetReferencedAssetsMapping()
    {
        AssetFileInfo info = null;

        foreach (var inf in assets.file.GetAssetsOfType(AssetClassID.MonoBehaviour))
        {
            string name = AssetHelper.GetAssetNameFast(assets.file, mgr.ClassDatabase, inf);
            if (name == "BlueprintReferencedAssets")
            {
                info = inf;
                break;
            }
        }

        AssetTypeValueField baseField = mgr.GetBaseField(assets, info, AssetReadFlags.None);

        return baseField["m_Entries"]["Array"].Children.ToDictionary(
            keySelector: x => x["AssetId"].AsString, 
            elementSelector: x => new ReferencedAssetItem()
            {
                AssetId = x["AssetId"].AsString,
                FileId = x["FileId"].AsLong,
                AssetFileID = x["Asset"]["m_FileID"].AsLong,
                AssetPathID = x["Asset"]["m_PathID"].AsLong,
            }
        );
    }

    private sealed record class ReferencedAssetItem
    {
        public string AssetId { get; init; }
        public long FileId { get; init; }
        public long AssetFileID { get; init; }
        public long AssetPathID { get; init; }
    }

    private ushort? GetScriptTypeIndex(string className)
    {
        for (ushort i = 0; i < assets.file.Metadata.ScriptTypes.Count; i++)
        {
            AssetPPtr pptr = assets.file.Metadata.ScriptTypes[i];
            var info = assets.file.GetAssetInfo(pptr.PathId);
            if (info == null) { continue; }
            var baseField = mgr.GetBaseField(assets, info, AssetReadFlags.None);
            string ns = baseField["m_Namespace"].AsString;
            string cls = baseField["m_ClassName"].AsString;

            if (cls == className)
            {
                return i;
            }
        }

        return null;
    }

    public void Dispose()
    {
        bundle = null;
        assets = null;

        mgr.UnloadAll();
    }

    private static JToken RecurseJsonDump(AssetTypeValueField field, bool uabeFlavor = false)
    {
        AssetTypeTemplateField template = field.TemplateField;
        if (template.IsArray)
        {
            JArray jArray = new JArray();
            if (template.ValueType != AssetValueType.ByteArray)
            {
                for (int i = 0; i < field.Children.Count; i++)
                {
                    jArray.Add(RecurseJsonDump(field.Children[i], uabeFlavor));
                }
            }
            else
            {
                byte[] byteArrayData = field.AsByteArray;
                for (int j = 0; j < byteArrayData.Length; j++)
                {
                    jArray.Add(byteArrayData[j]);
                }
            }
            return jArray;
        }
        if (field.Value == null)
        {
            JObject jObject = new JObject();
            foreach (AssetTypeValueField child in field)
            {
                if (child.FieldName == string.Empty)
                    continue;

                jObject.Add(child.FieldName, RecurseJsonDump(child, uabeFlavor));
            }
            return jObject;
        }
        AssetValueType evt = field.Value.ValueType;
        if (field.Value.ValueType != AssetValueType.ManagedReferencesRegistry)
        {
            object obj;
            switch (evt)
            {
                case AssetValueType.Bool:
                    obj = field.AsBool;
                    break;
                case AssetValueType.Int8:
                case AssetValueType.Int16:
                case AssetValueType.Int32:
                    obj = field.AsInt;
                    break;
                case AssetValueType.UInt8:
                case AssetValueType.UInt16:
                case AssetValueType.UInt32:
                    obj = field.AsUInt;
                    break;
                case AssetValueType.Int64:
                    obj = field.AsLong;
                    break;
                case AssetValueType.UInt64:
                    obj = field.AsULong;
                    break;
                case AssetValueType.Float:
                    obj = field.AsFloat;
                    break;
                case AssetValueType.Double:
                    obj = field.AsDouble;
                    break;
                case AssetValueType.String:
                    obj = field.AsString;
                    break;
                default:
                    obj = "invalid value";
                    break;
            }
            return (JValue)JToken.FromObject(obj);
        }
        ManagedReferencesRegistry registry = field.Value.AsManagedReferencesRegistry;
        if (registry.version == 1 || registry.version == 2)
        {
            JArray jArrayRefs = new JArray();
            foreach (AssetTypeReferencedObject refObj in registry.references)
            {
                AssetTypeReference typeRef = refObj.type;
                JObject jObjManagedType = new JObject
                    {
                        { "class", typeRef.ClassName },
                        { "ns", typeRef.Namespace },
                        { "asm", typeRef.AsmName }
                    };
                JObject jObjData = new JObject();
                foreach (AssetTypeValueField child2 in refObj.data)
                {
                    jObjData.Add(child2.FieldName, RecurseJsonDump(child2, uabeFlavor));
                }
                JObject jObjRefObject;
                if (registry.version == 1)
                {
                    jObjRefObject = new JObject
                        {
                            { "type", jObjManagedType },
                            { "data", jObjData }
                        };
                }
                else
                {
                    jObjRefObject = new JObject
                        {
                            { "rid", refObj.rid },
                            { "type", jObjManagedType },
                            { "data", jObjData }
                        };
                }
                jArrayRefs.Add(jObjRefObject);
            }
            return new JObject
                {
                    { "version", registry.version },
                    { "RefIds", jArrayRefs }
                };
        }

        throw new NotSupportedException($"Registry version {registry.version} is not supported!");
    }

    private sealed record class LocalizedTextItem
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public string Key { get; init; }

        [JsonPropertyName("file_path")]
        public string OwnerPath { get; init; }

        [JsonPropertyName("asset_guid")]
        public string OwnerString { get; init; }

        [JsonPropertyName("asset_type")]
        public string OnwerType { get; init; }

        [JsonPropertyName("string_path")]
        public string OwnerPropertyPath { get; init; }

        [JsonPropertyName("shared")]
        public bool Shared { get; set; }
    }
}
