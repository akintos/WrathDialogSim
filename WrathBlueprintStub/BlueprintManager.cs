using Kingmaker.Blueprints;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker
{
    public class BlueprintManager
    {
        private static BlueprintManager _instance;

        private readonly JsonSerializer serializer;

        private readonly Dictionary<Guid, SimpleBlueprint> BlueprintDict = new Dictionary<Guid, SimpleBlueprint>();

        public readonly HashSet<string> MissingClassNames = new HashSet<string>();

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
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                Error = IgnoreMissingTypeErrorHandler,
                SerializationBinder = new IgnoreAssemblyNameBinder(),
            };
            serializer = JsonSerializer.Create(settings);
        }

        public SimpleBlueprint GetBlueprint(string guid)
        {
            return BlueprintDict[new Guid(guid)];
        }

        public SimpleBlueprint GetBlueprint(Guid guid)
        {
            return BlueprintDict[guid];
        }

        public void LoadBlueprintDirectory(string path)
        {
            foreach (var item in Directory.GetFiles(path, "*.json", SearchOption.AllDirectories))
            {
                // AnswersList_0001.9476bee1e1a84f9abe1d5a72fcf7b7e3.json
                var guidString = Path.GetExtension(Path.GetFileNameWithoutExtension(item)).Substring(1);
                var guid = new Guid(guidString);

                var bp = DeserializeBlueprintFile(item);
                BlueprintDict.Add(guid, bp);
            }
        }

        private SimpleBlueprint DeserializeBlueprintFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var jsonreader = new JsonTextReader(reader))
            {
                return (SimpleBlueprint)serializer.Deserialize(jsonreader);   
            }
        }

        private SimpleBlueprint DeserializeBluerpintString(string jsonString)
        {
            using (var textReader = new StringReader(jsonString))
            using (var jsonreader = new JsonTextReader(textReader))
            {
                return (SimpleBlueprint)serializer.Deserialize(jsonreader);
            }
        }

        private void IgnoreMissingTypeErrorHandler(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs args)
        {
            /// Error resolving type specified in JSON 'Kingmaker.Designers.EventConditionActionSystem.Actions.ToggleObjectFx, Assembly-CSharp'.
            /// Path 'OnSelect.Actions[0].IfTrue.Actions[0].$type', line 58, position 111.
            string msg = args.ErrorContext.Error.Message;
            if (msg.StartsWith("Error resolving type specified in JSON"))
            {
                int startpos = msg.IndexOf('\'') + 1;
                int endpos = msg.IndexOf(',');
                string classname = msg.Substring(startpos, endpos - startpos);
                MissingClassNames.Add(classname);

                args.ErrorContext.Handled = true;
            }
        }

        public class IgnoreAssemblyNameBinder : ISerializationBinder
        {
            private readonly Dictionary<string, Type> TypeCache = new Dictionary<string, Type>();

            public IgnoreAssemblyNameBinder()
            {
                var thisAssembly = Assembly.GetAssembly(typeof(IgnoreAssemblyNameBinder));
                foreach (var type in thisAssembly.GetTypes())
                {
                    TypeCache.Add(type.FullName, type);
                }
            }

            public Type BindToType(string assemblyName, string typeName)
            {
                if (TypeCache.TryGetValue(typeName, out Type type))
                {
                    return type;
                }
                return default;
            }

            public void BindToName(Type serializedType, out string assemblyName, out string typeName)
            {
                assemblyName = serializedType.Assembly.GetName().Name;
                typeName = serializedType.Name;
            }
        }
    }
}
