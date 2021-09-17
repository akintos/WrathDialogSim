using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class FloatConstant : FloatEvaluator
	{
		public override string GetCaption()
		{
			return Value.ToString();
		}

		public float Value;
	}
}
