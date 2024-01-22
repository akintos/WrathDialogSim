using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SpawnFx : GameAction
	{
		public override string GetCaption()
		{
			return $"SpawnFx({FxPrefab.name}, {Target})";
		}

		public TransformEvaluator Target;
		public GameObject FxPrefab;
	}
}
