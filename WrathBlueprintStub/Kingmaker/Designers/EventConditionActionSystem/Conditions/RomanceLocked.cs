using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class RomanceLocked : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("RomanceLocked({0})", m_Romance);
        }

        public BlueprintReferenceBase m_Romance;
    }
}
