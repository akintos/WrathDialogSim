using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class AddFatigueHours : GameAction
    {
        public override string GetCaption()
        {
            string arg = Hours?.ToString() ?? "24";
            return string.Format("AddFatigueHours({0}, {1})", Unit, arg);
        }

        public IntEvaluator Hours;

        public UnitEvaluator Unit;
    }
}
