using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class GlobalMapTeleport : GameAction
	{
		public override string GetCaption()
		{
			return $"GlobalMapTeleport({Destination}, SkipHours: {SkipHours})";
		}

		public LocationEvaluator Destination;

		public FloatEvaluator SkipHours;
	}
}
