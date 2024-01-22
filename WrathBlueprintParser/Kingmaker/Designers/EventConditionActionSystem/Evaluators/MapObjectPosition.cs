using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class MapObjectPosition : PositionEvaluator
	{
		public override string GetCaption()
		{
			return $"MapObjectPosition({MapObject})";
		}

		public EntityReference MapObject;
	}
}
