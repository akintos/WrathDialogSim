using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class GiveObjective : GameAction
    {
        public override string GetCaption()
        {
            return $"GiveObjective({m_Objective})";
        }

        public BlueprintReferenceBase m_Objective;
    }
}
