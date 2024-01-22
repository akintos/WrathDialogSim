using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class ObjectiveStatus : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("ObjectiveStatus({0}, {1})", m_QuestObjective, State);
        }

        public BlueprintReferenceBase m_QuestObjective;

        public QuestObjectiveState State;

        public enum QuestObjectiveState
        {
            None,
            Started,
            Completed,
            Failed
        }
    }
}
