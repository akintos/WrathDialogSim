using System;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SetVendorPriceModifier : GameAction
	{
		public override string GetCaption()
		{
			var entry = m_Entries[0];
			return $"SetVendorPriceModifier(BuyModifier: {entry.BuyModifier}, SellModifier: {entry.SellModifier})";
		}

		public UnitEvaluator VendorUnit;

		public Entry[] m_Entries;

		public class Entry
		{
			public ConditionsChecker Condition;
			public FloatEvaluator BuyModifier;
			public FloatEvaluator SellModifier;
		}
	}
}
