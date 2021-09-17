using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class IntToFloat : FloatEvaluator
	{
		public override string GetCaption()
		{
			return Value;
		}

		public IntEvaluator Value;
	}
}
