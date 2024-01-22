using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class PartyUnits : GameAction
    {
        public override string GetCaption()
        {
            return string.Format("PartyUnits({0}, {1})", m_UnitsList, Actions.LambdaFormat());
        }

        public CharactersList m_UnitsList;

        public ActionList Actions;

        public enum CharactersList
        {
            ActiveUnits = 0,
            Everyone = 1,
            AllDetachedUnits = 3,
            DetachedPartyCharacters = 4,
            PartyCharacters = 5,
        }
    }
}
