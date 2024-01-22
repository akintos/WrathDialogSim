using System;
using System.Linq;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class MonthFromList : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"MonthsFromList({string.Join(", ", Months)})";
        }

        public int[] Months;
    }
}
