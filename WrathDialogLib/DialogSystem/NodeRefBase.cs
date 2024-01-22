namespace WrathDialogLib.DialogSystem;

[JsonConverter(typeof(NodeRefBaseJsonConverter))]
public class NodeRefBase : IEquatable<NodeRefBase>
{
    public string Guid;

    private BaseNode? _cache;

    public NodeRefBase(string guid)
    {
        Guid = guid;
    }

    public virtual BaseNode Get()
    {
        _cache ??= DialogManager.GetNode(Guid);
        return _cache;
    }

    public static implicit operator BaseNode(NodeRefBase obj)
    {
        return obj.Get();
    }

    public bool Equals(NodeRefBase other)
    {
        return other?.Guid?.Equals(Guid) ?? false;
    }

    public override int GetHashCode()
    {
        return Guid.GetHashCode();
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
        string guid = reader.GetString()!;
        return (NodeRefBase)Activator.CreateInstance(typeToConvert, guid);
    }

    public override void Write(Utf8JsonWriter writer, NodeRefBase value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Guid);
    }
}
