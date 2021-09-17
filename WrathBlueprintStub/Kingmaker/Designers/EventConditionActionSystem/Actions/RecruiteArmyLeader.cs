using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RecruiteArmyLeader : GameAction
	{
		public override string GetCaption()
		{
			return $"RecruiteArmyLeader({ArmyLeader})";
		}

		public BlueprintReferenceBase ArmyLeader;
	}
}
