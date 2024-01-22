using System;
using Kingmaker.Blueprints;
using Kingmaker.Designers;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.UnitLogic.Mechanics.Actions
{
	public class ContextActionFinishObjective : GameAction
	{
		public override string GetCaption()
		{
			return $"FinishObjective({m_Objective})";
		}

		public BlueprintReferenceBase m_Objective;
	}
}
