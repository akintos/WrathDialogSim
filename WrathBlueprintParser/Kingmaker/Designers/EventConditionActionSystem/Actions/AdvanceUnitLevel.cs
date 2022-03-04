using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class AdvanceUnitLevel : GameAction
    {
        public override string GetCaption()
        {
            return $"AdvanceUnitLevel({Unit}, {Level})";
        }

        public UnitEvaluator Unit;

        public IntEvaluator Level;
    }
}
