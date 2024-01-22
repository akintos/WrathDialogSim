using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class HideMapObject : GameAction
	{
		public override string GetCaption()
		{
			return $"HideMapObject({MapObject}, {(Unhide ? "Show " : "Hide")})";
		}

		public MapObjectEvaluator MapObject;

		public bool Unhide;
	}
}
