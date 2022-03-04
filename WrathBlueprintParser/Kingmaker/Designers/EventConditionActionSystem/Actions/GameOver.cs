using System;

using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class GameOver : GameAction
	{
		public override string GetCaption()
		{
			return $"GameOver({Reason})";
		}

		public string Reason;
	}
}
