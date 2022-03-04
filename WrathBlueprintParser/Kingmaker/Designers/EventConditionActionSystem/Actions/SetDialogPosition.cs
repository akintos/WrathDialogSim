using System;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SetDialogPosition : GameAction
	{
		public override string GetCaption()
		{
			return $"SetDialogPosition({Position})";
		}

		public PositionEvaluator Position;
	}
}
