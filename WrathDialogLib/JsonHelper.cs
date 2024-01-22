using System.Text.Encodings.Web;

namespace WrathDialogLib;

public static class JsonHelper
{
    private static readonly JsonSerializerOptions options = new()
    {
        IncludeFields = true,
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        IgnoreReadOnlyProperties = true,
        IgnoreReadOnlyFields = true,
    };

    public static async Task SerializeJsonAsync<T>(string path, T obj)
    {
        using Stream file = File.Create(path);
        await JsonSerializer.SerializeAsync(file, obj, options);
    }

    public static async Task<T> DeserializeJsonAsync<T>(string path)
    {
        using Stream file = File.OpenRead(path);
        T result = await JsonSerializer.DeserializeAsync<T>(file, options)
            ?? throw new NullReferenceException($"Failed to deserialize JSON file {path} to type {typeof(T)}");
        return result;
    }
}
