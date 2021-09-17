using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class CompanionInParty : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"CompanionInParty({m_companion})";
        }

        public BlueprintUnitReference m_companion;

        public bool MatchWhenActive = true;
        public bool MatchWhenDetached;
        public bool MatchWhenRemote;
        public bool MatchWhenDead;
        public bool MatchWhenEx;
    }
}
