using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class AttachBuff : GameAction
    {
        public override string GetCaption()
        {
            return string.Format("AttachBuff({0}, {1}, {2})", m_Buff, Target, Duration);
        }

        public BlueprintReferenceBase m_Buff;

        public UnitEvaluator Target;

        public IntEvaluator Duration;
    }
}
