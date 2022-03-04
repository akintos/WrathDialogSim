using System;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class MapObjectLoot : ItemsCollectionEvaluator
	{
		public override string GetCaption()
		{
			return $"MapObjectLoot({MapObject})";
		}

		public MapObjectEvaluator MapObject;
	}
}
