using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class MovePartyItemsAction : GameAction
	{
		public override string GetCaption()
		{
			return $"MovePartyItemsAction({PickupTypes})";
		}

		public string PickupTypes;
	}
}
