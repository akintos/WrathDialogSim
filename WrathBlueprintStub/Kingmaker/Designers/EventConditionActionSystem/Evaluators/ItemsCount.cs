using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	public class ItemsCount : IntEvaluator
	{
		public override string GetCaption()
		{
			return $"ItemsCount({m_Item})";
		}

		public BlueprintItemReference m_Item;
	}
}
