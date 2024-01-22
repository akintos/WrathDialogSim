using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class UnitIsDead : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("UnitIsDead({0})", Target);
        }


        public UnitEvaluator Target;
    }
}
