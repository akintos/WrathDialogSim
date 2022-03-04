using System;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class AlignmentCheck : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("Alignment {0}", this.Alignment);
        }

        public AlignmentComponent Alignment;
    }
}
