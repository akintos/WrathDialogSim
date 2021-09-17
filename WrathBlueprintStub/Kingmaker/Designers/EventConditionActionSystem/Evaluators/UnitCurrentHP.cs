using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class UnitCurrentHP : IntEvaluator
	{
		public override string GetCaption()
		{
			return $"UnitCurrentHP({Unit})";
		}

		public UnitEvaluator Unit;
	}
}
