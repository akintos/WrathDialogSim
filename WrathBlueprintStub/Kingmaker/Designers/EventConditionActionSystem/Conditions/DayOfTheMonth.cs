using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class DayOfTheMonth : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"DayOfTheMonth({Day})";
        }

        public int Day;
    }
}
