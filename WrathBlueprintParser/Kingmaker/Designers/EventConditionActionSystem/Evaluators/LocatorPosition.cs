using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    [Serializable]
    public class LocatorPosition : PositionEvaluator
    {
        public override string GetCaption()
        {
            return Locator.EntityNameInEditor;
        }

        public EntityReference Locator;
    }
}
