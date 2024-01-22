using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class PlayerAlignmentIs : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"PlayerAlignmentIs({Alignment})";
        }

        public string Alignment;
    }
}
