using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class MapObjectTransform : TransformEvaluator
	{
		public override string GetCaption()
		{
			return MapObject.ToString();
		}

		public EntityReference MapObject;
	}
}
