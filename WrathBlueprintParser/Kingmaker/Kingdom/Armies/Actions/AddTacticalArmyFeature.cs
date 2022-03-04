using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Kingdom.Armies.Actions
{
	public class AddTacticalArmyFeature : GameAction
	{
		public override string GetCaption()
		{
			var features = string.Join(", ", m_Features.Select(x => x.ToString()));
			if (this.m_ByTag)
			{
				return $"AddTacticalArmyFeature([{features}], {m_Faction}, {m_ArmyTag})";
			}
			if (this.m_ByUnits)
			{
				var units = string.Join(", ", m_ArmyUnits.Select(x => x.ToString()));
				return $"AddTacticalArmyFeature([{features}], {m_Faction}, {units})";
			}
			return $"AddTacticalArmyFeature([{features}], {m_Faction})";
		}

		public bool m_ByTag;

		public string m_ArmyTag;

		public bool m_ByUnits;

		public BlueprintUnitReference[] m_ArmyUnits;

		public BlueprintFeatureReference[] m_Features;

		public string m_Faction;
	}
}
