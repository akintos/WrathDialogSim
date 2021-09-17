using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SpotUnit : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("SpotUnit({0}, {1})", Spotter ?? "MainCharacter", Target);
		}

		public UnitEvaluator Target;
		public UnitEvaluator Spotter;
	}
}
