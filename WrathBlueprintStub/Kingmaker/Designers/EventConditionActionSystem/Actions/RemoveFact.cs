using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RemoveFact : GameAction
	{
		public override string GetCaption()
		{
			return $"RemoveFact({Unit}, {m_Fact})";
		}

		public UnitEvaluator Unit;
		public BlueprintReferenceBase m_Fact;
	}
}
