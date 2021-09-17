using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items;

using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class MakeItemNonRemovable : GameAction
	{
		public override string GetCaption()
		{
			return $"MakeItemNonRemovable({m_Item})";
		}

		public BlueprintItemReference m_Item;

		public bool NonRemovable = true;
	}
}
