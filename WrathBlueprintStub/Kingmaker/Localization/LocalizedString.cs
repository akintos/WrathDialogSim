using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kingmaker.Blueprints;

using Newtonsoft.Json;

namespace Kingmaker.Localization
{
    // [JsonConverter(typeof(LocalizedStringCovnerter))]
    public class LocalizedString : BlueprintReferenceBase
    {
        public string Key => Guid.ToString("N");
        public string Value => Name;

        public static implicit operator string(LocalizedString ls) => ls.Name;

        public override string ToString() => Name;
    }

    //public class LocalizedStringCovnerter : JsonConverter<LocalizedString>
    //{
    //    public override bool CanRead => true;
    //    public override bool CanWrite => true;

    //    public override LocalizedString ReadJson(JsonReader reader, Type objectType, LocalizedString existingValue, bool hasExistingValue, JsonSerializer serializer)
    //    {
    //        string text = (string)reader.Value;
    //        string[] parts = text.Split(new char[] { ':' }, 3);
    //        return new LocalizedString() { Key = parts[1], Value = parts[2] };
    //    }

    //    public override void WriteJson(JsonWriter writer, LocalizedString value, JsonSerializer serializer)
    //    {
    //        writer.WriteValue($"LocalizedString:{value.Key:N}:{value.Value}");
    //    }
    //}
}
