using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RevealGlobalMap : GameAction
	{
		public override string GetCaption()
		{
			var points = string.Join(", ", Points.Select(x => x.ToString()));
			return $"RevealGlobalMap({points})";
		}

		public BlueprintReferenceBase[] Points;
	}
}
