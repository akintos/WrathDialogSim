using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class CheckItemCondition : Condition
    {
        protected override string GetConditionCaption()
        {
            if (m_RequiredState != CheckItemCondition.RequiredState.EquippedOn)
            {
                return $"CheckItemNotEquipped({m_TargetItem})";
            }
            else
            {
                return $"CheckItemEquipped({m_TargetItem})";
            }
        }

        public BlueprintReferenceBase m_TargetItem;

        public RequiredState m_RequiredState;

        public enum RequiredState
        {
            EquippedOn,
            NotEquippedOn
        }
    }
}