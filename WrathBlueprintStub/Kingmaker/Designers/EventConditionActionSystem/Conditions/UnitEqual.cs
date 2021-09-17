using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class UnitEqual : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("UnitEqual({0} == {1})", this.FirstUnit, this.SecondUnit);
        }

        public UnitEvaluator FirstUnit;

        public UnitEvaluator SecondUnit;
    }
}
