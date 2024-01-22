using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class UnitIsHidden : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("UnitIsHidden({0})", this.Unit);
        }

        public UnitEvaluator Unit;
    }
}
