using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class MarkLocationClosed : GameAction
	{
		public override string GetCaption()
		{
			return $"MarkLocationClosed({m_Location}, Closed: {Closed})";
		}

		public BlueprintReferenceBase m_Location;

		public bool Closed = true;
	}
}
