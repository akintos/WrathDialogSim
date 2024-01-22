using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class StopCutscene : GameAction
	{
		public override string GetCaption()
		{
			return $"StopCutscene({m_Cutscene})";
		}

		public BlueprintReferenceBase m_Cutscene;
	}
}
