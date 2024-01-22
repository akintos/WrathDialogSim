using System;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RemoveAmbush : GameAction
	{
		public override string GetCaption()
		{
			return $"RemoveAmbush({m_Unit}, ExitStealth: {m_ExitStealth})";
		}

		public UnitEvaluator m_Unit;
		public bool m_ExitStealth;
	}
}
