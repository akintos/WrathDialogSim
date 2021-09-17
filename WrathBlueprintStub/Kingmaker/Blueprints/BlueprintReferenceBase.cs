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
        public string Name;

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator string(BlueprintReferenceBase obj)
        {
            return obj.Name;
        }

        public static implicit operator bool(BlueprintReferenceBase obj)
        {
            return !(obj is null) && obj.Name != "NULL";
        }
    }

    public class BlueprintReferenceBaseCovnerter : JsonConverter<BlueprintReferenceBase>
    {
        public override bool CanRead => true;
        public override bool CanWrite => true;

        public override BlueprintReferenceBase ReadJson(JsonReader reader, Type objectType, BlueprintReferenceBase existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string text = (string)reader.Value;
            string[] parts = text.Split(new char[] { ':' }, 3);
            string guidpart = parts[1];
            Guid guid;
            if (!Guid.TryParse(guidpart, out guid))
            {
                guid = Guid.Empty;
            }
            var obj = (BlueprintReferenceBase)Activator.CreateInstance(objectType);
            obj.Guid = guid;
            obj.Name = parts[2];
            
            return obj;
        }

        public override void WriteJson(JsonWriter writer, BlueprintReferenceBase value, JsonSerializer serializer)
        {
            writer.WriteValue($"{value.GetType().Name}:{value.Guid:N}:{value.Name}");
        }
    }
}
