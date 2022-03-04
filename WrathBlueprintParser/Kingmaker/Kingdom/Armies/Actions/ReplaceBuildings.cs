using System;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace Kingmaker.Kingdom.Armies.Actions
{
	public class ReplaceBuildings : KingdomAction
	{
		public override string GetCaption()
		{
			return $"ReplaceBuildings({m_OldBuilding}, {m_NewBuilding})";
		}

		public BlueprintReferenceBase m_OldBuilding;
		public BlueprintReferenceBase m_NewBuilding;
	}
}
