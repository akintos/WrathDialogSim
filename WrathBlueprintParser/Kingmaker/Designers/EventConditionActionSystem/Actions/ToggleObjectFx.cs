using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ToggleObjectFx : GameAction
	{
		public override string GetCaption()
		{
			string format = "ToggleObjectFx({0}, {1})";
			return string.Format(format, Target?.GetCaption() ?? "None", ToggleOn ? "ON" : "OFF");
		}

		public MapObjectEvaluator Target;
		public bool ToggleOn;
	}
}
