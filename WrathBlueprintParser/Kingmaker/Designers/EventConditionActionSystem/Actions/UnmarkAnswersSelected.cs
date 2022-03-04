using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class UnmarkAnswersSelected : GameAction
	{
		public override string GetCaption()
		{
			string answers = string.Join(", ", m_Answers.Select(x => x.Guid.ToString().Substring(0, 8)));
			return $"UnmarkAnswersSelected({answers})";
		}

		public BlueprintAnswerReference[] m_Answers;
	}
}
