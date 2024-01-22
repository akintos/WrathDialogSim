using System;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace Kingmaker.Kingdom.Armies.Actions
{
	public class AddMercenaryToPool : KingdomAction
	{
		public override string GetCaption()
		{
			return $"AddMercenaryToPool({m_Unit})";
		}

		public BlueprintUnitReference m_Unit;
	}
}
