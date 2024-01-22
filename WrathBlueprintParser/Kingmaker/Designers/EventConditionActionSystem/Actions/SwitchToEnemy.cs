using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SwitchToEnemy : GameAction
	{
		public override string GetCaption()
		{
			return $"SwitchToEnemy({Target}, FactionToAttack: {m_FactionToAttack})";
		}

		public UnitEvaluator Target;
		public BlueprintReferenceBase m_FactionToAttack;
	}
}
