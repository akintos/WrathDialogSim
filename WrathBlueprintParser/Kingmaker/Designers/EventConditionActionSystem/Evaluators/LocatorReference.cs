using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    public class LocatorReference : LocatorEvaluator
    {
        public override string GetCaption()
        {
            return this.Locator.ToString();
        }

        public EntityReference Locator;
    }
}
