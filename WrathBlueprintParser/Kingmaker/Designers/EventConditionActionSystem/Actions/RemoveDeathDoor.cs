using System;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RemoveDeathDoor : GameAction
	{
		public override string GetCaption()
		{
			return $"RemoveDeathDoor({Unit})";
		}

		public UnitEvaluator Unit;
	}
}
