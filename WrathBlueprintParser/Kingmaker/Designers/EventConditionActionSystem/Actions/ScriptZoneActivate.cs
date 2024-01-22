using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ScriptZoneActivate : GameAction
	{
		public override string GetCaption()
		{
			return $"ScriptZoneActivate({ScriptZone})";
		}

		public EntityReference ScriptZone;
	}
}
