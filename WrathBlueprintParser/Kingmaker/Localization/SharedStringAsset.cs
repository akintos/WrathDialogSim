using Newtonsoft.Json;
using UnityEngine;

namespace Kingmaker.Localization;

public sealed class SharedStringAsset : ScriptableObject
{
    [JsonProperty("assetguid")]
    public string AssetGuid { get; set; }

    [JsonProperty("stringkey")]
    public string StringKey { get; set; }

    public SharedStringAsset(string assetGuid, string stringKey)
    {
        AssetGuid = assetGuid;
        StringKey = stringKey;
    }
    
    public string Get() => KingmakerResourceManager.Instance.GetTranslation(StringKey);
}
