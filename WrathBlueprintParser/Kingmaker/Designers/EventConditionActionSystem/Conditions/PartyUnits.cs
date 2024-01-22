using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class PartyUnits : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("PartyUnits({0}, {1})", Any ? "any" : "all", Conditions.ToString());
        }

        public bool Any;
        public ConditionsChecker Conditions;
    }
}
