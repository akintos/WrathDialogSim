using System;

using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class UnitLookAt : GameAction
	{
		public override string GetCaption()
		{
			return $"UnitLookAt({Unit}, {Position})";
		}

		public UnitEvaluator Unit;
		public PositionEvaluator Position;
	}
}
