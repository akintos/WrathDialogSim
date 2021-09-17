using System;
using Kingmaker.Blueprints;

using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class Play2DSound : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("Play2DSound({0})", SoundName);
		}

		public string SoundName;
	}
}
