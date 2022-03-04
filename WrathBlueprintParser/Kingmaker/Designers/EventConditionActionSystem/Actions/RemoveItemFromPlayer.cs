using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class RemoveItemFromPlayer : GameAction
    {
        public override string GetCaption()
        {
            if (Money) return $"RemoveItemFromPlayer(money, {Quantity})";
            if (RemoveAll) return $"RemoveItemFromPlayer(all)";
            return  $"RemoveItemFromPlayer({m_ItemToRemove}, {Quantity})";
        }

        public bool Money;
        public bool RemoveAll;
        public BlueprintReferenceBase m_ItemToRemove;
        public int Quantity = 1;
        public float Percentage;
    }
}
