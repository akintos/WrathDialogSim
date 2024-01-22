using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class QuestStatus : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("QuestStatus({0}, {1})", m_Quest, State);
        }

        public BlueprintReferenceBase m_Quest;

        public string State;
    }
}
