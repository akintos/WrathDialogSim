using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class GreaterThan : Condition
    {
        protected override string GetConditionCaption()
        {
            string a = FloatValues ? FloatValue?.ToString() : Value?.ToString();
            string b = FloatValues ? FloatMinValue?.ToString() : MinValue?.ToString();

            return $"GreaterThan({a} > {b})";
        }

        public bool FloatValues;

        public IntEvaluator Value;
        public IntEvaluator MinValue;

        public FloatEvaluator FloatValue;
        public FloatEvaluator FloatMinValue;
    }
}
