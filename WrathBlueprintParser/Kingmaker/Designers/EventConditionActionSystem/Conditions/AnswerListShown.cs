using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class AnswerListShown : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("AnswerListShown({0})", m_AnswersList.Guid.ToString("N")[..8]);
        }

        public BlueprintAnswersListReference m_AnswersList;

        public bool CurrentDialog;
    }
}
