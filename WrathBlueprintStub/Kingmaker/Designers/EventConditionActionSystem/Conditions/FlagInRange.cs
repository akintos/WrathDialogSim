using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class FlagInRange : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("FlagInRange({0}, {1}, {2})", m_Flag, MinValue, MaxValue);
        }

        public BlueprintReferenceBase m_Flag;

        public int MinValue;

        public int MaxValue;
    }
}
