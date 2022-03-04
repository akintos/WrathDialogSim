using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SellCollectibleItems : GameAction
	{
		public override string GetCaption()
		{
			return $"SellCollectibleItems({m_ItemToSell}, HalfPrice: {HalfPrice})";
		}

		public BlueprintItemReference m_ItemToSell;

		public bool HalfPrice;
	}
}
