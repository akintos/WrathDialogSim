using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Blueprints
{
    [Serializable]
    public class SimpleBlueprint
    {
        [JsonProperty]
        public string ProtypeLink;

        [JsonProperty]
        public string Comment;
    }
}
