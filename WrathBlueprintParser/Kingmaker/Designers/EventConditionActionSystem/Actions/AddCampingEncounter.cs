using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class AddCampingEncounter : GameAction
    {
        public override string GetCaption()
        {
            return string.Format("AddCampingEncounter({0})", m_Encounter);
        }

        public BlueprintReferenceBase m_Encounter;
    }
}
