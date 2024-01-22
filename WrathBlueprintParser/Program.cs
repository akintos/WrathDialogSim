using WrathDialogLib;

namespace WrathBlueprintParser;

class Program
{
    internal static string GAME_DIR = @"D:\SteamLibrary\steamapps\common\Pathfinder Second Adventure";

    public static void Main(string[] args)
    {
        KingmakerResourceManager mgr = KingmakerResourceManager.Instance;
        mgr.Initialize(GAME_DIR);

        mgr.LoadJbpZipFile(BlueprintFilter);
        Console.WriteLine($"Loaded blueprints : " + mgr.BlueprintDict.Count);

        using LocalizedTextsExtractor extractor = new(GAME_DIR, mgr.GuidTypenameDict);
        extractor.ExtractAll();
        extractor.ExportJson(GetDataFilePath("localizedtexts.json"));

        KingmakerBlueprintConverter converter = new();
        converter.DialogDefaultSpeakers = extractor.DialogSpeakerDict;

        SerializedDialog db = converter.ConvertBlueprints(mgr);

        db.SerializeAsync(GetDataFilePath("database.json")).GetAwaiter().GetResult();

        var gen = new DialogDataGenerator(db);
        gen.Run(outputPath: GetDataFilePath("dialog_data.json"));
    }

    internal static string GetDataFilePath(string fileName)
    {
        return Path.Combine("..", "..", "..", "..", "data", fileName);
    }

    private static bool BlueprintFilter(string typename)
    {
        if (typename == "Kingmaker.Blueprints.BlueprintUnit") return true;
        // if (typename == "Kingmaker.AreaLogic.Cutscenes.Commands.CommandStartDialog") return true;

        return typename.StartsWith("Kingmaker.DialogSystem") &&
            typename != "Kingmaker.DialogSystem.Blueprints.BlueprintDialogExperienceModifierTable" &&
            typename != "Kingmaker.DialogSystem.Blueprints.BlueprintMythicInfo" &&
            typename != "Kingmaker.DialogSystem.Blueprints.BlueprintMythicsSettings";
    }
}
