namespace WrathBlueprintParser;

internal class TimestampedDataContainer<T>
{
    public DateTime Timestamp { get; set; }

    public T Data { get; set; }

    public static DateTime BlueprintsTimestamp => File.GetLastWriteTime(Path.Combine(Program.GAME_DIR, "blueprints.zip"));

    public static T LoadOrCreate(string jsonPath, Func<T> createFunc)
    {
        Console.WriteLine($"Loading {Path.GetFileNameWithoutExtension(jsonPath)}...");

        TimestampedDataContainer<T> container = default;

        if (File.Exists(jsonPath))
        {
            using Stream fs = File.OpenRead(jsonPath);
            container = System.Text.Json.JsonSerializer.Deserialize<TimestampedDataContainer<T>>(fs);
        }

        if (container == null || container.Timestamp < BlueprintsTimestamp)
        {
            T data = createFunc();
            container = new() { Timestamp = BlueprintsTimestamp, Data = data };

            using Stream fs = File.Create(jsonPath);
            System.Text.Json.JsonSerializer.Serialize(fs, container);
        }

        return container.Data;
    }
}
