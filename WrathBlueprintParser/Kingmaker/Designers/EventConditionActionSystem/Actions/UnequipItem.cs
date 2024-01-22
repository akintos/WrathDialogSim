using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;

using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class UnequipItem : GameAction
	{
		public override string GetCaption()
		{
			return $"UnequipItem({m_Item}, {Unit})";
		}

		public UnitEvaluator Unit;
		public BlueprintItemReference m_Item;
	}
}
