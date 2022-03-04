using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SwitchFaction : GameAction
	{
		public override string GetCaption()
		{
			return $"SwitchFaction({Target}, {m_Faction})";
		}

		public UnitEvaluator Target;
		public BlueprintReferenceBase m_Faction;
	}
}
