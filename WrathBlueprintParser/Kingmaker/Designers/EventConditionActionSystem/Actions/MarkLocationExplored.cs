using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class MarkLocationExplored : GameAction
	{
		public override string GetCaption()
		{
			return $"MarkLocationExplored({m_Location}, Explored: {Explored})";
		}

		public BlueprintReferenceBase m_Location;

		public bool Explored = true;
	}
}
