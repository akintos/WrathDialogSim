using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WrathDialogSim;

internal class WeblateData : Dictionary<string, DialogueUnit>
{
    public static WeblateData LoadJson(string path)
    {
        using (var stream = File.OpenRead(path))
        {
            return JsonSerializer.DeserializeAsync<WeblateData>(stream).Result;
        }

    }

    public async static Task<WeblateData> LoadJsonAsync(string path)
    {
        using (var stream = File.OpenRead(path))
        {
            return await JsonSerializer.DeserializeAsync<WeblateData>(stream);
        }                
    }

    public static WeblateData LoadCsv(string path)
    {
        var result = new WeblateData();
        string row;

        using (var reader = new StreamReader(path))
        {
            while (!string.IsNullOrWhiteSpace(row = reader.ReadLine()))
            {
                var parts = row.Split(',');
                if (parts.Length != 3)
                    throw new IOException("Failed to parse CSV file");
                var key = parts[0].ToLowerInvariant();
                int id = int.Parse(parts[1]);
                int pos = int.Parse(parts[2]);

                result.Add(key, new DialogueUnit() { id = id, pos = pos });
            }
        }

        return result;
    }
}
