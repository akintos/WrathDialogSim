using System;
using Kingmaker.ElementsSystem;
using Kingmaker.RuleSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class DrainEnergy : GameAction
	{
		public override string GetCaption()
		{
			var source = NoSource ? "NoSource" : Source;
			return $"DrainEnergy({Target}, {source}, {Type}, {DamageDice})";
		}

		public bool NoSource;

		public UnitEvaluator Source;
		public UnitEvaluator Target;

		public string Type;

		public DiceFormula DamageDice;
	}
}
