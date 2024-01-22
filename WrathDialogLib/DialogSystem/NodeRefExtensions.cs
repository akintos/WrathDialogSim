namespace WrathDialogLib.DialogSystem;

public static class NodeRefExtensions
{
    public static NodeRef<T> ToReference<T>(this T node) where T : BaseNode
    {
        return new NodeRef<T>(node.Guid);
    }
}
