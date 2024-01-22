using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Blueprints
{
    [JsonConverter(typeof(BlueprintReferenceBaseCovnerter))]
    [Serializable]
    public class BlueprintReferenceBase
    {
        public Guid Guid;

        public string Name => KingmakerResourceManager.Instance.GetBlueprintName(Guid) ?? Guid.ToString("N");

        public string ShortGuid => Guid.ToString("N")[..8];

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator string(BlueprintReferenceBase obj)
        {
            return obj?.Name;
        }

        public static implicit operator bool(BlueprintReferenceBase obj)
        {
            return obj is not null && obj.Name != "NULL";
        }

        public SimpleBlueprint Get()
        {
            if (Guid == System.Guid.Empty)
                return null;

            return KingmakerResourceManager.Instance.GetBlueprint(Guid);
        }
    }

    public class BlueprintReferenceBaseCovnerter : JsonConverter<BlueprintReferenceBase>
    {
        public override bool CanRead => true;
        public override bool CanWrite => true;

        public override BlueprintReferenceBase ReadJson(JsonReader reader, Type objectType, BlueprintReferenceBase existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string text = (string)reader.Value;
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            if (text.StartsWith("!bp_"))
            {
                var bpref = (BlueprintReferenceBase)Activator.CreateInstance(objectType);
                bpref.Guid = new Guid(text[4..]);
                return bpref;
            }

            string[] parts = text.Split(new char[] { ':' }, 3);
            string guidpart = parts[1];
            Guid guid;
            if (!Guid.TryParse(guidpart, out guid))
            {
                guid = Guid.Empty;
            }
            var obj = (BlueprintReferenceBase)Activator.CreateInstance(objectType);
            obj.Guid = guid;
            
            return obj;
        }

        public override void WriteJson(JsonWriter writer, BlueprintReferenceBase value, JsonSerializer serializer)
        {
            if (value.Guid == Guid.Empty)
                writer.WriteValue($"{value.GetType().Name}::{value.Name}");
            else
                writer.WriteValue($"{value.GetType().Name}:{value.Guid:N}:{value.Name}");
        }
    }
}
