using System;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class DestroyUnit : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("DestroyUnit({0})", this.Target);
		}

		public UnitEvaluator Target;
	}
}
