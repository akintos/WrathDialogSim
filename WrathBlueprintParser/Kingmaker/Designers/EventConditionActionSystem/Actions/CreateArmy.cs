using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Kingdom;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class CreateArmy : GameAction
	{
		public override string GetCaption()
		{
			return $"CreateArmy({Preset}, {Location}, {Faction})";
		}

		public string Faction;

		public BlueprintReferenceBase Preset;

		public BlueprintReferenceBase Location;

		public bool WithLeader;
	}
}
