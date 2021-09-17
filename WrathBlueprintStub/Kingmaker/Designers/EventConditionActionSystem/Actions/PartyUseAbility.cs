using System;

using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class PartyUseAbility : GameAction
	{
		public override string GetCaption()
		{
			return $"PartyUseAbility({Description}, AllowItems: {AllowItems})";
		}

		public AbilitiesHelper.AbilityDescription Description;

		public bool AllowItems;
	}
}
