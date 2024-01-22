using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class TeleportParty : GameAction
    {
        public override string GetCaption()
        {
            return string.Format("Teleport Party ({0})", m_exitPositon);
        }

        public BlueprintReferenceBase m_exitPositon;
    }
}
