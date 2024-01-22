using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class HideWeapons : GameAction
	{
		public override string GetCaption()
		{
			return $"HideWeapons({Target}, {(this.Hide ? "Hide" : "Show")})";
		}

		public UnitEvaluator Target;

		public bool Hide = true;
	}
}
