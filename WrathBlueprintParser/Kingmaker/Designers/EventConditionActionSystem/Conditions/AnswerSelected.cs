using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class AnswerSelected : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"AnswerSelected({m_Answer?.ShortGuid})";
        }

        public BlueprintAnswerReference m_Answer;

        public bool CurrentDialog;
    }
}
