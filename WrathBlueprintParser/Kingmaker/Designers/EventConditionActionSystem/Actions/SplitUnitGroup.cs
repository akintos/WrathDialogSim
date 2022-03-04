using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SplitUnitGroup : GameAction
	{
		public override string GetCaption()
		{
			return $"SplitUnitGroup({Target})";
		}

		public UnitEvaluator Target;
	}
}
