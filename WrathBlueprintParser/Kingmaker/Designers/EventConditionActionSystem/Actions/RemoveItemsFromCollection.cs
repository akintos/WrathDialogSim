using System;
using System.Collections.Generic;
using Kingmaker.Blueprints.Loot;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RemoveItemsFromCollection : GameAction
	{
		public override string GetCaption()
		{
			return $"RemoveItemsFromCollection({Collection}, {Loot})";
		}

		public ItemsCollectionEvaluator Collection;
		public List<LootEntry> Loot;
	}
}
