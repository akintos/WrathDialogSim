using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class AnswerSelected : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("Answer Selected ({0})", m_Answer);
        }

        public BlueprintAnswerReference m_Answer;

        public bool CurrentDialog;
    }
}
