using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class MarkAnswersSelected : GameAction
	{
		public override string GetCaption()
		{
			string anwers = string.Join(", ", m_Answers.Select(x => x.ToString()));
			return "MarkAnswersSelected(" + anwers + ")";
		}

		public BlueprintAnswerReference[] m_Answers;
	}
}
