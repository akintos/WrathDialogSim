using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class UnitFromSummonPool : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("UnitFromSummonPool({0}, {1})", Unit, m_SummonPool);
        }
        public UnitEvaluator Unit;

        public BlueprintReferenceBase m_SummonPool;
    }
}
