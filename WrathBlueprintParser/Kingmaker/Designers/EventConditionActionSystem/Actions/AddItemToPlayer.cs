using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class AddItemToPlayer : GameAction
    {
        public override string GetCaption()
        {
            return string.Format("AddItemToPlayer({0}, {1})", m_ItemToGive, Quantity);
        }

        public BlueprintReferenceBase m_ItemToGive;

        public int Quantity = 1;
    }
}
