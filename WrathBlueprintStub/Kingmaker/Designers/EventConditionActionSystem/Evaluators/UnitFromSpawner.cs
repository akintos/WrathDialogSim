using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    public class UnitFromSpawner : UnitEvaluator
    {
        public override string GetCaption()
        {
            return $"UnitFromSpawner({Spawner})";
        }
        
        public EntityReference Spawner;
    }
}
