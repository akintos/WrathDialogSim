using SharpCompress.Archives.Zip;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace WrathBlueprintParser;

/*
 * {
 *     "AssetId": "93b239a961e5cb74c978a187ce3297ba",
 *     "Data": {
 *        "$type": "df78945bb9f434e40b897758499cb714, BlueprintAnswer"
 *     }
 * }
*/

internal class JbpCatalog : Dictionary<string, JbpCatalogEntry>
{
    const string CATALOG_JSON_PATH = "jbp_catalog.json";

    public static JbpCatalog LoadOrCreate(string jbpZipFilePath, Dictionary<string, string> guidTypenameDict)
    {
        return TimestampedDataContainer<JbpCatalog>.LoadOrCreate(
            CATALOG_JSON_PATH, 
            () => GetJbpCatalogData(jbpZipFilePath, guidTypenameDict));
    }

    public static JbpCatalog GetJbpCatalogData(string jbpZipFilePath, Dictionary<string, string> guidTypenameDict)
    {
        JbpCatalog result = new();

        using var archive = ZipArchive.Open(jbpZipFilePath);

        var files = archive.Entries.Where(x => x.Key.EndsWith(".jbp")).ToList();

        foreach (var zipEntry in files)
        {
            var obj = JsonNode.Parse(zipEntry.OpenEntryStream());

            string assetId = obj["AssetId"].GetValue<string>();

            string typeGuid = obj["Data"]["$type"].GetValue<string>()[..32];

            if (!guidTypenameDict.TryGetValue(typeGuid, out string typeName))
            {
                continue;
            }

            var entry = new JbpCatalogEntry()
            {
                Name = Path.GetFileNameWithoutExtension(zipEntry.Key),
                Path = zipEntry.Key,
                TypeName = typeName,
                TypeGuid = typeGuid,
            };

            result.Add(assetId, entry);
        }

        return result;
    }
}

internal record class JbpCatalogEntry
{
    [JsonPropertyName("guid")]
    public string Guid { get; set; }

    [JsonPropertyName("type")]
    public string TypeName { get; set; }

    [JsonPropertyName("type_id")]
    public string TypeGuid { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}