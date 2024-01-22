using System;

using Kingmaker.ElementsSystem;
using Kingmaker.Localization;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ShowMessageBox : GameAction
	{
		public override string GetCaption()
		{
			return $"ShowMessageBox({Text.Key})";
		}

		public LocalizedString Text;
	}
}
