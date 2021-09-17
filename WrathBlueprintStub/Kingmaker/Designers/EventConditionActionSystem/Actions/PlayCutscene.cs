using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class PlayCutscene : GameAction
    {
        public override string GetCaption()
        {
            return $"PlayCutscene({m_Cutscene})";
        }

        public BlueprintReferenceBase m_Cutscene;
    }
}
