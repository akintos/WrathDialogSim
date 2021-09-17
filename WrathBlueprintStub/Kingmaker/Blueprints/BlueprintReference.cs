
namespace Kingmaker.Blueprints
{
    public class BlueprintReference<T> : BlueprintReferenceBase where T : SimpleBlueprint
    {
        public T Get()
        {
            return (T)BlueprintManager.Instance.GetBlueprint(Guid);
        }
    }
}
