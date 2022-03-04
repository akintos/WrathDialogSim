using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class CurrentAreaIs : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"CurrentAreaIs({m_Area})";
        }

        public BlueprintReferenceBase m_Area;
    }
}
