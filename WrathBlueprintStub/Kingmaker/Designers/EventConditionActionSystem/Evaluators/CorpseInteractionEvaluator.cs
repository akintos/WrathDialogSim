using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class CorpseInteractionEvaluator : MapObjectEvaluator
	{
		public override string GetCaption()
		{
			return $"CorpseInteractionEvaluator({m_UnitSpawner})";
		}

		public EntityReference m_UnitSpawner;
	}
}
