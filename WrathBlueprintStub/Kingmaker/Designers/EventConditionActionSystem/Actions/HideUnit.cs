using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class HideUnit : GameAction
	{
		public override string GetCaption()
		{
			string str = this.Unhide ? "Show " : "Hide";
			return $"HideUnit({Target}, {str})";
		}

		public UnitEvaluator Target;

		public bool Unhide;
	}
}
