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
        public string Name;

        [JsonProperty]
        public string Comment;

        public string Guid;

        public static implicit operator BlueprintReferenceBase(SimpleBlueprint obj)
        {
            return new BlueprintReferenceBase() { Guid = new Guid(obj.Guid), Name = obj.Name };
        }
    }
}
