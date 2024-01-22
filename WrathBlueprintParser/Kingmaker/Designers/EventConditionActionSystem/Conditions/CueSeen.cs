using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class CueSeen : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"CueSeen({m_Cue.Guid.ToString("N")[..8]})";
        }

        public BlueprintCueBaseReference m_Cue;

        public bool CurrentDialog;
    }
}
