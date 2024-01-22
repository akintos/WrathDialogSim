using System;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class StartCombat : GameAction
	{
		public override string GetCaption()
		{
			return $"StartCombat({Unit1}, {Unit2})";
		}

		public UnitEvaluator Unit1;
		public UnitEvaluator Unit2;
	}
}
