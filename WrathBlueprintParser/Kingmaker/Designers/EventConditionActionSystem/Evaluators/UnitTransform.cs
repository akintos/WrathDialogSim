using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class UnitTransform : TransformEvaluator
	{
		public override string GetCaption()
		{
			return Unit.ToString();
		}

		public UnitEvaluator Unit;
	}
}
