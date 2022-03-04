using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class HealUnit : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("HealUnit{0}", this.Target);
		}

		public UnitEvaluator Target;
	}
}
