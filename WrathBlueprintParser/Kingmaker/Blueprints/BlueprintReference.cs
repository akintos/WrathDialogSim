
namespace Kingmaker.Blueprints
{
    public class BlueprintReference<T> : BlueprintReferenceBase where T : SimpleBlueprint
    {
        public T Get()
        {
            if (Guid == System.Guid.Empty)
                return null;

            return (T)BlueprintManager.Instance.GetBlueprint(Guid);
        }
    }
}
