using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class SummonPoolUnitsCount : IntEvaluator
	{
		public override string GetCaption()
		{
			return $"SummonPoolUnitsCount({m_SummonPool})";
		}

		public BlueprintReferenceBase m_SummonPool;
	}
}
