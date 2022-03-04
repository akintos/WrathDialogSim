using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class Conditional : GameAction
    {

        public override string GetCaption()
        {
            if (IfFalse.IsEmpty)
                return $"if ({ConditionsChecker}) {{{IfTrue}}}";
            else
                return $"if ({ConditionsChecker}) {{{IfTrue}}} else {{{IfFalse}}}";
        }

        public string Comment;

        public ConditionsChecker ConditionsChecker;

        public ActionList IfTrue;

        public ActionList IfFalse;
    }
}
