using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class Recruit : GameAction
	{
		public override string GetCaption()
		{
			return $"Recruit({Recruited[0].m_CompanionBlueprint})";
		}

		public Recruit.RecruitData[] Recruited;

		[Serializable]
		public class RecruitData
		{
			public BlueprintUnitReference m_CompanionBlueprint;
			public UnitEvaluator NPCUnit;
			public bool MustBeInParty;
		}
	}
}
