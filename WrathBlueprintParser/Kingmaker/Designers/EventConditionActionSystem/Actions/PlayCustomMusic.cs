using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class PlayCustomMusic : GameAction
	{
		public override string GetCaption()
		{
			return $"PlayCustomMusic({MusicEventStart}, {MusicEventStop})";
		}

		public string MusicEventStart;
		public string MusicEventStop;
	}
}
