using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class ClosestArmiesEvaluator : ArmiesEvaluator
	{
		public override string GetCaption()
		{
			return $"ClosestArmiesEvaluator({m_Position}, {Faction})";
		}

		public string Faction;
		public BlueprintReferenceBase m_Position;
	}
}
