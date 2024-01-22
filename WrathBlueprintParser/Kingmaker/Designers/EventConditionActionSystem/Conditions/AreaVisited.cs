using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Assets.Designers.EventConditionActionSystem.Conditions
{
	public class AreaVisited : Condition
	{
		protected override string GetConditionCaption()
		{
			return string.Format("AreaVisited({0})", m_Area);
		}

		public BlueprintReferenceBase m_Area;
	}
}
