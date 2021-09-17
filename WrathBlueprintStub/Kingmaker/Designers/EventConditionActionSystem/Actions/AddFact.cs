using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class AddFact : GameAction
    {
        public override string GetCaption()
        {
            return $"AddFact({Unit}, {m_Fact})";
        }

        public UnitEvaluator Unit;

        public BlueprintReferenceBase m_Fact;
    }
}
