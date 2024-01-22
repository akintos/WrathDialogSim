using Newtonsoft.Json;

namespace Kingmaker.Localization;

public sealed class LocalizedString
{
    [JsonProperty]
    private readonly string m_Key;

    [JsonProperty(PropertyName = "m_OwnerString")]
    public string OwnerString { get; set; }

    [JsonProperty(PropertyName = "m_OwnerPropertyPath")]
    public string OwnerPropertyPath { get; set; }

    public SharedStringAsset Shared { get; set; } 

    private LocalizedString()
    {
    }

    public LocalizedString(string key)
    {
        m_Key = key;
    }

    public LocalizedString(string key, SharedStringAsset shared)
    {
        m_Key = key;
        Shared = shared;
    }

    public string Key => Shared?.StringKey ?? m_Key;

    public string Value => KingmakerResourceManager.Instance.GetTranslation(Key);

    public bool IsEmptyKey => string.IsNullOrEmpty(Key);

    public static implicit operator WrathDialogLib.LocalizedString(LocalizedString ls)
    {
        return new WrathDialogLib.LocalizedString(ls.Key, ls.Value);
    }

    public override string ToString() => Value;
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
