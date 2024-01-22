using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class PartyCanUseAbility : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("PartyCanUseAbility({0}, {1})", Description, AllowItems ? " AllowItems" : "");
        }

        public AbilitiesHelper.AbilityDescription Description;

        public bool AllowItems;
    }
}
