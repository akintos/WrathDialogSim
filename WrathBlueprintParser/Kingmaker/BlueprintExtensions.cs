using WrathDialogLib.DialogSystem;

namespace Kingmaker;

public static class BlueprintExtensions
{
    public static NodeRefBase ToNodeRef(this BlueprintReferenceBase bpref)
    {
        return new NodeRefBase(bpref.Guid.ToString("N"));
    }

    public static List<NodeRefBase> ToNodeRefList<T>(this IEnumerable<T> blueprintList) where T : BlueprintReferenceBase
    {
        return new List<NodeRefBase>(blueprintList.Select(ToNodeRef));
    }

    public static NodeRefBase[] ToNodeRefArray<T>(this IEnumerable<T> blueprintList) where T : BlueprintReferenceBase
    {
        return blueprintList.Select(ToNodeRef).ToArray();
    }
}
