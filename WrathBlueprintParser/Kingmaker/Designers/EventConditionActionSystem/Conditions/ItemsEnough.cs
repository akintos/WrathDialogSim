using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class ItemsEnough : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"ItemsEnough({m_ItemToCheck}, {Quantity})";
        }

        public bool Money;

        public BlueprintReferenceBase m_ItemToCheck;

        public int Quantity;
    }
}
