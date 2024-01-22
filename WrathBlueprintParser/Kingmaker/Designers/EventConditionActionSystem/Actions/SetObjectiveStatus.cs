using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class SetObjectiveStatus : GameAction
    {
        public override string GetCaption()
        {
            return $"SetObjectiveStatus({m_Objective}, {Status})";
        }

        public string Status;

        public BlueprintReferenceBase m_Objective;
    }
}
