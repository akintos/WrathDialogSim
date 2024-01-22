using System;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace Kingmaker.Kingdom.Armies.Actions
{
	public class ExchangeRecruits : KingdomAction
	{
		public override string GetCaption()
		{
			return $"ExchangeRecruits({m_OldUnit}, {m_NewUnit}, {ConvertCoefficient})";
		}

		public float ConvertCoefficient = 1f;

		public BlueprintUnitReference m_OldUnit;

		public BlueprintUnitReference m_NewUnit;
	}
}
