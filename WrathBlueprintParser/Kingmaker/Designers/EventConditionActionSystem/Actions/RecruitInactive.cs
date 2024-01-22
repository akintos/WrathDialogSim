using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RecruitInactive : GameAction
	{
		public override string GetCaption()
		{
			return $"RecruitInactive({m_CompanionBlueprint})";
		}

		public BlueprintUnitReference m_CompanionBlueprint;
	}
}
