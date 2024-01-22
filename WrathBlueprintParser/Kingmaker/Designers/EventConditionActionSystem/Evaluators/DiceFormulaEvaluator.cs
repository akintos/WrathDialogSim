using System;
using Kingmaker.ElementsSystem;
using Kingmaker.RuleSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class DiceFormulaEvaluator : IntEvaluator
	{
		public override string GetCaption()
		{
			return DiceFormula.ToString();
		}

		public DiceFormula DiceFormula;
	}
}
