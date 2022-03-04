using AssetsTools.NET.Extra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WrathSpawnerDataExtracter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bundlesDir = @"D:\Steam\steamapps\common\Pathfinder Second Adventure\Bundles";
            string outputPath = "../../../../data/spawnerdata.txt";

            SpawnerDataExtracter extracter = new(bundlesDir);

            var result = extracter.Run();

            using TextWriter sw = new StreamWriter(outputPath);
            foreach (var kvpair in result)
            {
                sw.WriteLine(kvpair.Key + ":" + kvpair.Value);
            }
        }
    }
}
