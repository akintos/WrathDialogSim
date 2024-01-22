namespace Kingmaker.Blueprints;

[Serializable]
public class SimpleBlueprint
{
    public string Name;

    public string Path;

    public string Comment;

    public string ParentAsset;

    public string Guid;

    public static implicit operator BlueprintReferenceBase(SimpleBlueprint obj)
    {
        return new BlueprintReferenceBase() { Guid = new Guid(obj.Guid) };
    }
}
