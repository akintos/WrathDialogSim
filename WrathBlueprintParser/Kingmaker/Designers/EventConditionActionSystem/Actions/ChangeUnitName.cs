using System;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class ChangeUnitName : GameAction
    {
        public override string GetCaption()
        {
            return $"ChangeUnitName({Unit}, \"{NewName}\")";
        }

        public UnitEvaluator Unit;

        public LocalizedString NewName;
    }
}
