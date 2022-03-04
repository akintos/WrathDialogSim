using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SummonUnitCopy : GameAction
	{
		public override string GetCaption()
		{
			return $"SummonUnitCopy({CopyFrom}, OnSummon: {{{OnSummon}}})";
		}

		public UnitEvaluator CopyFrom;
		public LocatorEvaluator Locator;
		public BlueprintUnitReference m_CopyBlueprint;
		public bool DoNotCreateItems;
		public ActionList OnSummon;
	}
}
