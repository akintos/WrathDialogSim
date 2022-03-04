using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class CheckPassed : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("CheckPassed({0})", m_Check);
        }

        public BlueprintReferenceBase m_Check;
    }
}
