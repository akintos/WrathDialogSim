using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.Designers;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.UnitLogic.Mechanics.Conditions
{
	public class ContextConditionHasItem : Condition
	{
		protected override string GetConditionCaption()
		{
			return $"HasItem({(Money ? "Money" : m_ItemToCheck)}, {Quantity})";
		}

		public bool Money;

		public BlueprintItemReference m_ItemToCheck;

		public int Quantity;
	}
}
