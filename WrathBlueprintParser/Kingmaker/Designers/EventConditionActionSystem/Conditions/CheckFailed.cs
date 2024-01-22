using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class CheckFailed : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("CheckFailed({0})", m_Check);
        }

        public BlueprintReferenceBase m_Check;
    }
}
