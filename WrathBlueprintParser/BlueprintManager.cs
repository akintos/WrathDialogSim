using Kingmaker.Blueprints;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker
{
    public class BlueprintManager
    {
        private static BlueprintManager _instance;

        internal readonly JsonSerializer serializer;

        internal readonly Dictionary<Guid, SimpleBlueprint> BlueprintDict = new();

        internal readonly HashSet<string> MissingClassNames = new();
        internal readonly HashSet<string> MissingFieldNames = new();

        public static BlueprintManager Instance
        {
            get
            {
                if (_instance is null)
                    _instance = new BlueprintManager();
                return _instance;
            }
        }

        private BlueprintManager()
        {
            JsonSerializerSettings settings = new()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                Error = IgnoreMissingTypeErrorHandler,
                // MissingMemberHandling = MissingMemberHandling.Error,
                SerializationBinder = new IgnoreAssemblyNameBinder(),
            };
            serializer = JsonSerializer.Create(settings);
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

        public void LoadBlueprintZipFile(string zipPath, Func<string, bool> filter = null)
        {
            using ZipArchive f = ZipFile.OpenRead(zipPath);
            List<ZipArchiveEntry> files = f.Entries.Where(x => x.FullName.EndsWith(".json")).ToList();

            for (int i = 0; i < files.Count; i++)
            {
                Console.Write($"Loading blueprint {i} / {files.Count}\r");
                var entry = files[i];
                if (filter != null && filter(entry.FullName) == false)
                continue;

                // AnswersList_0001.9476bee1e1a84f9abe1d5a72fcf7b7e3.json
                string filename = Path.GetFileNameWithoutExtension(entry.FullName);
                string guidString = Path.GetExtension(filename)[1..];
                Guid guid = new Guid(guidString);
                string bpname = Path.GetFileNameWithoutExtension(filename);

                using Stream stream = entry.Open();
                using StreamReader streamReader = new StreamReader(stream);
                using JsonTextReader jsonReader = new JsonTextReader(streamReader);

                SimpleBlueprint bp = serializer.Deserialize<SimpleBlueprint>(jsonReader);
                bp.Name = bpname;
                bp.Guid = guidString;
                BlueprintDict.Add(guid, bp);
            }
            Console.WriteLine("\nFinished loading zip file.");
        }

        public void LoadBlueprintDirectory(string directoryPath)
        {
            foreach (var item in Directory.GetFiles(directoryPath, "*.json", SearchOption.AllDirectories))
            {
                // AnswersList_0001.9476bee1e1a84f9abe1d5a72fcf7b7e3.json
                string filename = Path.GetFileNameWithoutExtension(item);
                string guidString = Path.GetExtension(filename).Substring(1);
                Guid guid = new Guid(guidString);
                string bpname = Path.GetFileNameWithoutExtension(filename);

                SimpleBlueprint bp = DeserializeBlueprintFile(item);
                bp.Name = bpname;
                bp.Guid = guidString;
                BlueprintDict.Add(guid, bp);
            }
        }

        private SimpleBlueprint DeserializeBlueprintFile(string filePath)
        {
            using var reader = new StreamReader(filePath);
            using var jsonreader = new JsonTextReader(reader);

            return (SimpleBlueprint)serializer.Deserialize(jsonreader);
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
                MissingClassNames.Add(classname);

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

        public class IgnoreAssemblyNameBinder : DefaultSerializationBinder
        {
            private readonly Dictionary<string, Type> TypeCache = new();

            public IgnoreAssemblyNameBinder() : base()
            {
                var thisAssembly = Assembly.GetAssembly(typeof(IgnoreAssemblyNameBinder));
                foreach (var type in thisAssembly.GetTypes())
                {
                    TypeCache.Add(type.FullName, type);
                }
            }

            public override Type BindToType(string assemblyName, string typeName)
            {
                if (TypeCache.TryGetValue(typeName, out var type))
                    return type;

                if (assemblyName == "Assembly-CSharp")
                    return null;

                return base.BindToType(Assembly.GetExecutingAssembly().GetName().Name, typeName);
            }
        }
    }
}
