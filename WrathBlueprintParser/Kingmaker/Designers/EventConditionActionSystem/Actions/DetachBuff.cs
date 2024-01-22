using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class DetachBuff : GameAction
	{
		public override string GetCaption()
		{
			return $"DetachBuff({m_Buff}, {Target})";
		}

		public BlueprintReferenceBase m_Buff;

		public UnitEvaluator Target;
	}
}
