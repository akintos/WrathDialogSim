using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class CueSeen : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"CueSeen({m_Cue})";
        }

        public BlueprintCueBaseReference m_Cue;

        public bool CurrentDialog;
    }
}
