using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class OrAndLogic : Condition
    {
        protected override string GetConditionCaption()
        {
            return ConditionsChecker.ToString();
        }

        public string Comment;

        public ConditionsChecker ConditionsChecker;
    }
}
