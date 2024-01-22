using System;
using System.Runtime.CompilerServices;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class AskPlayerForLocationName : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("AskPlayerForLocationName({0})", m_Location);
		}

		public BlueprintReferenceBase m_Location;
	}
}
