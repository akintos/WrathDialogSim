using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class IncrementFlagValue : GameAction
    {
        public override string GetCaption()
        {
            return $"IncrementFlagValue({m_Flag}, {Value}, unlock: {UnlockIfNot})";
        }

        public BlueprintReferenceBase m_Flag;

        public IntEvaluator Value;

        public bool UnlockIfNot;
    }
}
