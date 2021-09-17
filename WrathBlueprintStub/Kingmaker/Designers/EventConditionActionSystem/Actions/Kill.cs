using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class Kill : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("Kill({0}, Killer: {1})", Target, Killer);
		}

		public UnitEvaluator Target;

		public UnitEvaluator Killer;
	}
}
