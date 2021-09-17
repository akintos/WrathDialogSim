using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class AnswerListShown : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("Answer List Shown ({0})", m_AnswersList);
        }

        public BlueprintAnswersListReference m_AnswersList;

        public bool CurrentDialog;
    }
}
