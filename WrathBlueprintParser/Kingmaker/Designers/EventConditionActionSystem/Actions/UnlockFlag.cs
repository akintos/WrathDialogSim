using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class UnlockFlag : GameAction
    {
        public override string GetCaption()
        {
            return $"UnlockFlag({m_flag}, {flagValue})";
        }

        public BlueprintReferenceBase m_flag;

        public int flagValue;
    }
}
