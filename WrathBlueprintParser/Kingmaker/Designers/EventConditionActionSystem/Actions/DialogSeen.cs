using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions
{
    public class DialogSeen : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"DialogSeen({m_Dialog})";
        }

        public BlueprintReferenceBase m_Dialog;
    }
}
