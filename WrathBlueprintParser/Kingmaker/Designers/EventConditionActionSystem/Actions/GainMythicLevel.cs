using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class GainMythicLevel : GameAction
	{
		public override string GetCaption()
		{
			return $"GainMythicLevel({Levels})";
		}

		public int Levels;
	}
}
