using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ScriptZoneDeactivate : GameAction
	{
		public override string GetCaption()
		{
			return $"ScriptZoneDeactivate({ScriptZone})";
		}

		public EntityReference ScriptZone;
	}
}
