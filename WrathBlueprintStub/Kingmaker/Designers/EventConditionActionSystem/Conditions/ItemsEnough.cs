using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class ItemsEnough : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("Items ({0} of {1})", Quantity, m_ItemToCheck);
        }

        public bool Money;

        public BlueprintReferenceBase m_ItemToCheck;

        public int Quantity;
    }
}
