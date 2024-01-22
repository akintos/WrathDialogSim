using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class AddUnitToSummonPool : GameAction
    {
        public override string GetCaption()
        {
            return $"AddUnitToSummonPool({Unit}, {m_SummonPool})";
        }

        public BlueprintReferenceBase m_SummonPool;

        public UnitEvaluator Unit;
    }
}
