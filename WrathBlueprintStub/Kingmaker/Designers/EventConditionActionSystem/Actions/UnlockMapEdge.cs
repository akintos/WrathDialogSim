using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class UnlockMapEdge : GameAction
	{
		public override string GetCaption()
		{
			return $"UnlockMapEdge({m_Edge})";
		}

		public BlueprintReferenceBase m_Edge;

		public bool OpenEdges;
	}
}
