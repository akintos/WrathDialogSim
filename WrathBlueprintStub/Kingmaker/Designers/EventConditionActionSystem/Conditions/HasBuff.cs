using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class HasBuff : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"HasBuff({Target}, {m_Buff})";
        }

        public UnitEvaluator Target;

        public BlueprintReferenceBase m_Buff;
    }
}
