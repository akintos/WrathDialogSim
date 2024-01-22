using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SetPortrait : GameAction
	{
		public override string GetCaption()
		{
			return $"SetPortrait({Unit}, {m_Portrait})";
		}

		public UnitEvaluator Unit;

		public BlueprintReferenceBase m_Portrait;
	}
}
