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

            var mgr = BlueprintManager.Instance;

            Console.WriteLine($"Loading blueprint zip file...");
            Console.WriteLine($"Path : {blueprintZipPath}");

            mgr.LoadBlueprintZipFile(@"C:\Users\akintos\Downloads\Blueprints1.1.6e.zip", BlueprintFilter);
            Console.WriteLine($"Loaded blueprints : " + mgr.BlueprintDict.Count);

            var converter = new KingmakerBlueprintConverter();
            converter.ConvertBlueprints(mgr);
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

        public static void TarBlueprints()
        {
            var mgr = BlueprintManager.Instance;

            mgr.LoadBlueprintDirectory(@"C:\Users\akintos\localization\wrath\DialogSystem");

            Console.WriteLine(mgr);

            foreach (var item in mgr.MissingClassNames)
            {
                Console.WriteLine(item);
            }

            using (var writer = new StreamWriter("Dialog.json"))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                var serializer = JsonSerializer.CreateDefault();
                serializer.Formatting = Formatting.Indented;
                serializer.TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple;
                serializer.TypeNameHandling = TypeNameHandling.All;
                serializer.Serialize(jsonWriter, mgr.BlueprintDict);
            }
        }
    }
}
