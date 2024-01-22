using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Kingdom.Armies.Actions
{
	public class UnlockUnitsGrowth : GameAction
	{
		public override string GetCaption()
		{
			return $"UnlockUnitsGrowth({m_Unit})";
		}

		public BlueprintUnitReference m_Unit;
	}
}
