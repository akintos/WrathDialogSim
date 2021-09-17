using System;

using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RemoveMythicLevels : GameAction
	{
		public override string GetCaption()
		{
			return $"RemoveMythicLevels({Levels})";
		}

		public int Levels = 1;
	}
}
