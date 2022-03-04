using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
	public class UnitInScriptZone : Condition
	{
		protected override string GetConditionCaption()
		{
			return $"UnitInScriptZone({Unit}, {ScriptZone})";
		}

		public UnitEvaluator Unit;

		public MapObjectEvaluator ScriptZone;
	}
}
