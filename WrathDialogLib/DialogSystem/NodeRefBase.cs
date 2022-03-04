using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WrathDialogLib.DialogSystem
{
    [JsonConverter(typeof(NodeRefBaseJsonConverter))]
    public class NodeRefBase
    {
        public string Guid;

        private BaseNode? _cache;

        public NodeRefBase(string guid)
        {
            Guid = guid;
        }

        public virtual BaseNode Get()
        {
            return _cache ??= DialogManager.GetNode(Guid);
        }

        public static implicit operator BaseNode(NodeRefBase obj)
        {
            return obj.Get();
        }
    }

    public class NodeRefBaseJsonConverter : JsonConverter<NodeRefBase>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(NodeRefBase) || typeToConvert.IsSubclassOf(typeof(NodeRefBase));
        }

        public override NodeRefBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string guid = reader.GetString();
            return (NodeRefBase)Activator.CreateInstance(typeToConvert, guid);
        }

        public override void Write(Utf8JsonWriter writer, NodeRefBase value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Guid);
        }
    }
}
