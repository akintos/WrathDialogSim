using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class MapObjectFromScene : MapObjectEvaluator
	{
		public override string GetCaption()
		{
			return $"MapObjectFromScene({MapObject})";
		}

		public EntityReference MapObject;
	}
}
