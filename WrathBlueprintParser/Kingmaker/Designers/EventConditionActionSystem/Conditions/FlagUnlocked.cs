using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class FlagUnlocked : Condition
    {
        protected override string GetConditionCaption()
        {
            if (SpecifiedValues.Count <= 0)
            {
                return string.Format("FlagUnlocked({0})", this.m_ConditionFlag);
            }
            string arg = string.Join(", ", from v in SpecifiedValues select v.ToString());
            if (ExceptSpecifiedValues)
            {
                return string.Format("FlagUnlocked({0} not {1})", this.m_ConditionFlag, arg);
            }
            return string.Format("FlagUnlocked({0} is {1})", this.m_ConditionFlag, arg);
        }

        public BlueprintReferenceBase m_ConditionFlag;

        public bool ExceptSpecifiedValues;

        public List<int> SpecifiedValues = new List<int>();
    }
}
