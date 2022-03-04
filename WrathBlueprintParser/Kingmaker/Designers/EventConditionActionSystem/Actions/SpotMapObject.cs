using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SpotMapObject : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("SpotMapObject({0}, {1})", Spotter, Target);
		}

		public MapObjectEvaluator Target;

		public UnitEvaluator Spotter;
	}
}
