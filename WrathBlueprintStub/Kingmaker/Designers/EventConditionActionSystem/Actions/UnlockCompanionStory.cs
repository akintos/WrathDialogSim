using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class UnlockCompanionStory : GameAction
	{
		public override string GetCaption()
		{
			return $"UnlockCompanionStory({m_Story})";
		}

		public BlueprintReferenceBase m_Story;
	}
}
