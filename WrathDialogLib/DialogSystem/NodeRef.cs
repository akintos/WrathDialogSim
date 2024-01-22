namespace WrathDialogLib.DialogSystem;

[JsonConverter(typeof(NodeRefConverterFactory))]
public class NodeRef<T> : NodeRefBase where T : BaseNode
{
    public NodeRef(string guid) : base(guid) { }

    public static implicit operator T(NodeRef<T> obj)
    {
        return (T)obj.Get();
    }

    public new T Get()
    {
        return (T)base.Get();
    }
}

public class NodeRefConverter<T> : JsonConverter<NodeRef<T>> where T : BaseNode
{
    public override NodeRef<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string guid = reader.GetString();
        return (NodeRef<T>)Activator.CreateInstance(typeToConvert, guid);
    }

    public override void Write(Utf8JsonWriter writer, NodeRef<T> value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Guid);
    }
}

public class NodeRefConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType) return false;

        return typeToConvert.GetGenericTypeDefinition() == typeof(NodeRef<>);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type wrappedType = typeToConvert.GetGenericArguments()[0];

        return (JsonConverter)Activator.CreateInstance(typeof(NodeRefConverter<>).MakeGenericType(wrappedType));
    }
}
