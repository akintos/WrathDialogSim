using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class UnitBlueprint : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"UnitBlueprint({m_Blueprint}, {Unit})";
        }

        public UnitEvaluator Unit;

        public BlueprintUnitReference m_Blueprint;
    }
}
