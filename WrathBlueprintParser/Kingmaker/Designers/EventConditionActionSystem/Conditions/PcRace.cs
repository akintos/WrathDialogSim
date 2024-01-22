using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class PcRace : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("PcRace({0})", Race);
        }

        public string Race;
    }
}
