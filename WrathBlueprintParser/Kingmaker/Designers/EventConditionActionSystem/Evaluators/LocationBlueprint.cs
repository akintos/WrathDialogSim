using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
	[Serializable]
	public class LocationBlueprint : LocationEvaluator
	{
		public override string GetCaption()
		{
			return m_Location ?? "";
		}

		public BlueprintReferenceBase m_Location;
	}
}
