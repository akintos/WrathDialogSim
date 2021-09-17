using System;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ShowDialogBox : GameAction
	{
		public override string GetCaption()
		{
			return $"ShowDialogBox({Text.Key})";
		}

		public LocalizedString Text;
	}
}
