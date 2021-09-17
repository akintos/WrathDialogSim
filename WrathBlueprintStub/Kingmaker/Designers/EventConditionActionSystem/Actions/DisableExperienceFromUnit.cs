using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class DisableExperienceFromUnit : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("DisableExperienceFromUnit({0})", this.Unit);
		}

		public UnitEvaluator Unit;
	}
}
