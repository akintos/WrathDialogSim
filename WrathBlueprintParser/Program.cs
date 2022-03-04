using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Kingmaker.DialogSystem.Blueprints;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using WrathDialogLib;

namespace Kingmaker
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string blueprintZipPath = @"C:\Users\akintos\Downloads\Blueprints1.1.6e.zip";

            var spawnerUnitData = LoadSpawnerUnitData(@"..\..\..\..\data\spawnerdata.txt");

            var mgr = BlueprintManager.Instance;

            Console.WriteLine($"Loading blueprint zip file...");
            Console.WriteLine($"Path : {blueprintZipPath}");

            mgr.LoadBlueprintZipFile(@"C:\Users\akintos\Downloads\Blueprints1.1.6e.zip", BlueprintFilter);
            Console.WriteLine($"Loaded blueprints : " + mgr.BlueprintDict.Count);

            var converter = new KingmakerBlueprintConverter();
            converter.SetEntityUnitData(spawnerUnitData);

            var db = converter.ConvertBlueprints(mgr);

            db.SerializeAsync(@"..\..\..\..\data\database.json").GetAwaiter().GetResult();
        }

        public static bool BlueprintFilter(string fullPath)
        {
            string dirName = Directory.GetParent(fullPath).Name;

            if (dirName == "Kingmaker.Blueprints.BlueprintUnit") return true;
            if (dirName == "Kingmaker.AreaLogic.Cutscenes.Commands.CommandStartDialog") return true;

            return dirName.StartsWith("Kingmaker.DialogSystem") &&
                dirName != "Kingmaker.DialogSystem.Blueprints.BlueprintDialogExperienceModifierTable" &&
                dirName != "Kingmaker.DialogSystem.Blueprints.BlueprintMythicInfo" &&
                dirName != "Kingmaker.DialogSystem.Blueprints.BlueprintMythicsSettings";
        }

        private static Dictionary<string, string> LoadSpawnerUnitData(string path)
        {
            Dictionary<string, string> result = new();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(':', StringSplitOptions.TrimEntries);
                    if (parts.Length == 2 && !string.IsNullOrWhiteSpace(parts[1]))
                    {
                        result[parts[0]] = parts[1];
                    }
                }
            }

            return result;
        }
    }
}
