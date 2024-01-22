using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    public class FirstUnitFromSummonPool : UnitEvaluator
    {
        public override string GetCaption()
        {
            return $"FirstUnitFromSummonPool({m_SummonPool})";
        }

        public BlueprintReferenceBase m_SummonPool;

        public ConditionsChecker Conditions;
    }
}
