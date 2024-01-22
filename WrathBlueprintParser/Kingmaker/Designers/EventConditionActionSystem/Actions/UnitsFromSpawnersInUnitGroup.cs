using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class UnitsFromSpawnersInUnitGroup : GameAction
	{
		public override string GetCaption()
		{
			return $"UnitsFromSpawnersInUnitGroup({m_Group}, Actions: {Actions.LambdaFormat()})";
		}

		public EntityReference m_Group;

		public ActionList Actions;
	}
}
