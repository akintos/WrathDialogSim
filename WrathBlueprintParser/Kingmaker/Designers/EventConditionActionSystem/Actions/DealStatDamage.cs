using System;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class DealStatDamage : GameAction
	{
		public override string GetCaption()
		{
			return $"DealStatDamage({Target}, {Source}, {Stat}, {DamageDice})";
		}

		public bool NoSource;

		public UnitEvaluator Source;

		public UnitEvaluator Target;

		public StatType Stat;

		public bool IsDrain;

		public DiceFormula DamageDice;

		public int DamageBonus;

		public bool DisableBattleLog;
	}
}
