using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    [Serializable]
    public struct ActionAndWeight
    {
        public int Weight;

        public ConditionsChecker Conditions;

        public ActionList Action;

        public override string ToString()
        {
            if (Conditions.Conditions.Length > 0)
            {
                return $"if ({Conditions}) {{ {Action} }}";
            }

            return Action.ToString();
        }
    }
}
