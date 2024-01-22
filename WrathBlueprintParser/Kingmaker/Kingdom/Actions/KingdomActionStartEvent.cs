using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace Kingmaker.Kingdom.Actions
{
	public class KingdomActionStartEvent : KingdomAction
	{
		public override string GetCaption()
		{
			string regionName = RandomRegion ? "RandomRegion" : m_Region;

			return $"StartEvent({m_Event}, {regionName}, {DelayDays} delay)";
		}

		public BlueprintReferenceBase m_Event;

		public BlueprintReferenceBase m_Region;

		public bool RandomRegion;

		public int DelayDays;
	}
}
