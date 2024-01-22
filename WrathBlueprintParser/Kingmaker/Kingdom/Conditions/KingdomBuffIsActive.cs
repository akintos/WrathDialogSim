using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Kingdom.Conditions
{
	public class KingdomBuffIsActive : Condition
	{
		protected override string GetConditionCaption()
		{
			return $"KingdomBuffIsActive({m_Blueprint})";
		}

		public BlueprintReferenceBase m_Blueprint;
	}
}
