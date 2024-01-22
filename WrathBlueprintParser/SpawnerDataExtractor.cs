using AssetsTools.NET;
using AssetsTools.NET.Extra;

namespace WrathBlueprintParser;

internal class SpawnerDataExtractor
{
    private readonly AssetsManager mgr;

    public string BundlesDirectory { get; init; }

    public Dictionary<string, string> SpawnerData { get; set; } = new();

    public static Dictionary<string, string> GetData(string bundlesDirectory)
    {
        return TimestampedDataContainer<Dictionary<string, string>>.LoadOrCreate(
            Path.Combine(Program.GetDataFilePath("spawner_data.json")),
            () => new SpawnerDataExtractor(bundlesDirectory).Run());
    }

    public SpawnerDataExtractor(string bundlesDirectory)
    {
        BundlesDirectory = bundlesDirectory;
        mgr = new AssetsManager();
    }

    public Dictionary<string, string> Run()
    {
        SpawnerData = new();

        foreach (var bundlePath in Directory.GetFiles(BundlesDirectory, "*.scenes"))
        {
            ProcessBundle(bundlePath);
        }

        return SpawnerData;
    }

    private void ProcessBundle(string bundlePath)
    {
        var bundleInstance = mgr.LoadBundleFile(bundlePath, unpackIfPacked: true);

        var bundleDirectoryInfo = bundleInstance.file.BlockAndDirInfo.DirectoryInfos;

        for (int i = 0; i < bundleDirectoryInfo.Length; i++)
        {
            var bundledFileEntry = bundleDirectoryInfo[i];
            string name = bundledFileEntry.Name;

            string ext = Path.GetExtension(name);

            if (ext != string.Empty && ext != ".sharedAssets")
                continue;

            AssetsFileInstance assetsFileInstance = mgr.LoadAssetsFileFromBundle(bundleInstance, i, loadDeps: false);

            if (assetsFileInstance == null) continue;

            ProcessAssetsFile(assetsFileInstance);
        }

        mgr.UnloadAllAssetsFiles();
        mgr.UnloadAllBundleFiles();
    }

    private void ProcessAssetsFile(AssetsFileInstance inst)
    {
        foreach (var info in inst.file.GetAssetsOfType((int)AssetClassID.MonoBehaviour))
        {
            // var baseField = mgr.GetTypeInstance(inst, info).GetBaseField();
            AssetTypeValueField baseField = mgr.GetBaseField(inst, info);

            if (baseField.Children.Count != 11)
                continue;

            if (baseField.Children[5].FieldName != "UniqueId" || baseField.Children[6].FieldName != "m_Blueprint")
            {
                continue;
            }

            string uniqueId = baseField.Children[5].AsString;
            string unitBlueprintGuid = baseField.Children[6].Children[0].AsString;

            // Console.WriteLine($"{uniqueId}:{unitBlueprintGuid}");

            SpawnerData[uniqueId] = unitBlueprintGuid;
        }
    }
}
