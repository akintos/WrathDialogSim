using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class MarkCuesSeen : GameAction
	{
		public override string GetCaption()
		{
			var cues = string.Join(", ", m_Cues.Select(x => x.Guid.ToString().Substring(0, 8)));
			return "Mark Cues Seen(" + cues + ")";
		}

		public BlueprintCueBaseReference[] m_Cues;
	}
}
