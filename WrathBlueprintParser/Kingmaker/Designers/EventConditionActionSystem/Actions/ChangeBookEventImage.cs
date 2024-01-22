using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.ResourceLinks;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ChangeBookEventImage : GameAction
	{
		public override string GetCaption()
		{
			return $"ChangeBookEventImage({m_Image})";
		}

		public WeakResourceLink m_Image;
	}
}
