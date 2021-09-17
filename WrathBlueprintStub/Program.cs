using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Kingmaker
{
    class Program
    {
        public static void Main(string[] args)
        {
            var mgr = BlueprintManager.Instance;

            mgr.LoadBlueprintDirectory(@"C:\Users\akintos\localization\pf_wotr\DialogSystem");

            Console.WriteLine(mgr);

            foreach (var item in mgr.MissingClassNames)
            {
                Console.WriteLine(item);
            }

        }
    }
}
