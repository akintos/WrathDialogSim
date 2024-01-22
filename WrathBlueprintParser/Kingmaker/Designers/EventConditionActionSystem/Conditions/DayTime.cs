using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class DayTime : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"DayTime({Time})";
        }

        public TimeOfDay Time;

        public enum TimeOfDay
        {
            Morning,
            Day,
            Evening,
            Night
        }
    }
}
