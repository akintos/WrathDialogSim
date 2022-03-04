using AssetsTools.NET.Extra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathSpawnerDataExtracter
{
    internal class SpawnerDataExtracter
    {
        private readonly AssetsManager mgr;

        public string BundlesDirectory { get; init; }

        public Dictionary<string, string> SpawnerData { get; set; } = new();

        public SpawnerDataExtracter(string bundlesDirectory)
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

            var bundleDirectoryInfo = bundleInstance.file.bundleInf6.dirInf;

            for (int i = 0; i < bundleDirectoryInfo.Length; i++)
            {
                var bundledFileEntry = bundleDirectoryInfo[i];
                string name = bundledFileEntry.name;

                if (Path.GetExtension(name) != string.Empty)
                    continue;

                AssetsFileInstance assetsFileInstance = mgr.LoadAssetsFileFromBundle(bundleInstance, i, loadDeps: false);

                ProcessAssetsFile(assetsFileInstance);
            }

            mgr.UnloadAllAssetsFiles();
            mgr.UnloadAllBundleFiles();
        }

        private void ProcessAssetsFile(AssetsFileInstance inst)
        {
            foreach (var info in inst.table.GetAssetsOfType((int)AssetClassID.MonoBehaviour))
            {
                var baseField = mgr.GetTypeInstance(inst, info).GetBaseField();

                if (baseField.childrenCount != 11)
                    continue;

                if (baseField.children[5].GetName() != "UniqueId" || baseField.children[6].GetName() != "m_Blueprint")
                {
                    continue;
                }

                string uniqueId = baseField.children[5].GetValue().AsString();
                string unitBlueprintGuid = baseField.children[6].children[0].GetValue().AsString();

                Console.WriteLine($"{uniqueId}:{unitBlueprintGuid}");

                SpawnerData[uniqueId] = unitBlueprintGuid;
            }
        }
    }
}
