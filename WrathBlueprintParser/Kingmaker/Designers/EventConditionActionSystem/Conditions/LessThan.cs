using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class LessThan : Condition
    {
        protected override string GetConditionCaption()
        {
            string a = FloatValues ? FloatValue?.ToString() : Value?.ToString();
            string b = FloatValues ? FloatMaxValue?.ToString() : MaxValue?.ToString();

            return $"LessThan({a} < {b})";
        }

        public bool FloatValues;

        public IntEvaluator Value;
        public IntEvaluator MaxValue;

        public FloatEvaluator FloatValue;
        public FloatEvaluator FloatMaxValue;
    }
}
