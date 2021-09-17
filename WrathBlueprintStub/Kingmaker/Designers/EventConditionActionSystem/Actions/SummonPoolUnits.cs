using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SummonPoolUnits : GameAction
	{
		public override string GetCaption()
		{
			return $"SummonPoolUnits({m_SummonPool}, Conditions: {{{Conditions}}}, Actions: {{{Actions}}})";
		}

		public BlueprintReferenceBase m_SummonPool;

		public ConditionsChecker Conditions;

		public ActionList Actions;
	}
}
