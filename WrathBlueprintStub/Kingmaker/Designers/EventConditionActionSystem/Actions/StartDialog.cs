using System;
using Kingmaker.Blueprints;

using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Localization;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class StartDialog : GameAction
	{
		public override string GetCaption()
		{
			return $"StartDialog({m_Dialogue.Guid.ToString().Substring(0, 8)}:{m_Dialogue.Name}, {DialogueOwner})";
		}

		public UnitEvaluator DialogueOwner;

		public BlueprintReferenceBase m_Dialogue;

		public LocalizedString SpeakerName;
	}
}
