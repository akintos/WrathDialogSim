using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class TranslocateUnit : GameAction
	{
		public override string GetCaption()
		{
			return $"TranslocateUnit({Unit}, {translocatePosition})";
		}

		public UnitEvaluator Unit;

		public EntityReference translocatePosition;
	}
}
