using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class DeleteUnitFromSummonPool : GameAction
	{
		public override string GetCaption()
		{
			return $"DeleteUnitFromSummonPool({Unit}, {m_SummonPool})";
		}

		public BlueprintReferenceBase m_SummonPool;

		public UnitEvaluator Unit;
	}
}
