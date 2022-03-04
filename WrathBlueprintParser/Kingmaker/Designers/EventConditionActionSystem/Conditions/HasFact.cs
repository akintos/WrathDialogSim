using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class HasFact : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("HasFact({0}, {1})", this.Unit, this.m_Fact);
        }

        public UnitEvaluator Unit;

        public BlueprintReferenceBase m_Fact;
    }
}
