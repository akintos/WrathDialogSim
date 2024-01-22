using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class UnitClass : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"UnitClass({Unit}, {m_Class}, minlevel: {MinLevel})";
        }

        public UnitEvaluator Unit;

        public BlueprintReferenceBase m_Class;

        public IntEvaluator MinLevel;
    }
}
