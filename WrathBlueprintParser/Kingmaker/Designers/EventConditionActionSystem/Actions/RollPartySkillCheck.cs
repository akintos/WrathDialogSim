using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RollPartySkillCheck : GameAction
	{
		public override string GetCaption()
		{
			return $"RollPartySkillCheck({Stat}, {DC})";
		}

		public StatType Stat;
		public int DC;
	}
}
