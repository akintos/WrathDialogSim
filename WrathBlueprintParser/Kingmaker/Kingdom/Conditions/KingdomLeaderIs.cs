using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Kingdom.Conditions
{
	public class KingdomLeaderIs : Condition
	{
		protected override string GetConditionCaption()
		{
			return string.Format("KingdomLeaderIs({0}, {1})", this.Leader, this.m_Unit);
		}

		public string Leader;

		public BlueprintUnitReference m_Unit;
	}
}
