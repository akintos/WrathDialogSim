using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class IsUnconscious : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("IsUnconscious({0})", Unit);
        }

        public UnitEvaluator Unit;
    }
}
