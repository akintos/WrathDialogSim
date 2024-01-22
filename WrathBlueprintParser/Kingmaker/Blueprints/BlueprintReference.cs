
namespace Kingmaker.Blueprints
{
    public class BlueprintReference<T> : BlueprintReferenceBase where T : SimpleBlueprint
    {
        public new T Get()
        {
            if (Guid == System.Guid.Empty)
                return null;

            return (T)KingmakerResourceManager.Instance.GetBlueprint(Guid);
        }
    }
}
