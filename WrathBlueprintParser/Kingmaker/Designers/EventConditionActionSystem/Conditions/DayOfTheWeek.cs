using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class DayOfTheWeek : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"DayOfTheWeek({Day})";
        }

        public DayOfWeek Day;
    }
}
