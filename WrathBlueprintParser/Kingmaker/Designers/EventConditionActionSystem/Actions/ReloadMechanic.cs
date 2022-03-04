using System;
using Kingmaker.Blueprints;

using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ReloadMechanic : GameAction
	{
		public override string GetCaption()
		{
			return $"ReloadMechanic({Desc})";
		}

		public string Desc = "Empty action";
		public bool ClearFx = true;
	}
}
