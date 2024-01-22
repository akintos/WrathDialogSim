using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class StartTrade : GameAction
    {
        public override string GetCaption()
        {
            return $"StartTrade {Vendor}";
        }

        public UnitEvaluator Vendor;
    }
}
