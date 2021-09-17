using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    [Serializable]
    public class UnitPosition : PositionEvaluator
    {
        public override string GetCaption()
        {
            return Unit.ToString();
        }

        public UnitEvaluator Unit;
    }
}
