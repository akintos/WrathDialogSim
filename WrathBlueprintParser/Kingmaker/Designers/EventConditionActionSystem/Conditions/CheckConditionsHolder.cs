using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class CheckConditionsHolder : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("CheckConditionsHolder : {0}", ConditionsHolder);
        }

        public BlueprintReferenceBase ConditionsHolder;
    }
}
