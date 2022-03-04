using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace WrathDialogLib
{
    public static class JsonHelper
    {
        private static readonly JsonSerializerOptions options = new()
        {
            IncludeFields = true,
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        public static async Task SerializeJsonAsync<T>(string path, T obj)
        {
            using var file = File.Create(path);
            await JsonSerializer.SerializeAsync(file, obj, options);
        }

        public static async Task<T> DeserializeJsonAsync<T>(string path)
        {
            using var file = File.OpenRead(path);
            return await JsonSerializer.DeserializeAsync<T>(file, options) ?? throw new NullReferenceException($"Failed to deserialize JSON file {path} to type {typeof(T)}");
        }
    }
}
