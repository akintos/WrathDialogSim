using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Blueprints
{
    [Serializable]
    public class EntityReference
    {
        public string EntityNameInEditor;

        [JsonProperty("_entity_id")]
        public string UniqueId;

        [JsonProperty("SceneAssetGuid")]
        public string SceneAssetGuid;

        public override string ToString() => EntityNameInEditor;
    }
}
