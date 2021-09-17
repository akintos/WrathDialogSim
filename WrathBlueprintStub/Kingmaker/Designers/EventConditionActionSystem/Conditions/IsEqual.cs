using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class IsEqual : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("IsEqual({0} == {1})", this.FirstValue, this.SecondValue);
        }

        public IntEvaluator FirstValue;

        public IntEvaluator SecondValue;
    }
}
