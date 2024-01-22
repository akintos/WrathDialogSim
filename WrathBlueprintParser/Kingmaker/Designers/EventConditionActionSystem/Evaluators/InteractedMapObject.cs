using System;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class InteractedMapObject : MapObjectEvaluator
	{
		public override string GetCaption()
		{
			return "InteractedMapObject";
		}
	}
}
