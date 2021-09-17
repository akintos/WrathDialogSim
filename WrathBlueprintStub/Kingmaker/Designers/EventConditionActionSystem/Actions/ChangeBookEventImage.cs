using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ChangeBookEventImage : GameAction
	{
		public override string GetCaption()
		{
			return $"ChangeBookEventImage({m_Image})";
		}

		public BlueprintReferenceBase m_Image;
	}
}
