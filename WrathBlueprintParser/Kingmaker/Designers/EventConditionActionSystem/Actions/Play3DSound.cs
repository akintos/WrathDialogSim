using System;
using Kingmaker.Blueprints;

using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class Play3DSound : GameAction
	{
		public override string GetCaption()
		{
			return $"Play3DSound({SoundName})";
		}

		public string SoundName;
	}
}
