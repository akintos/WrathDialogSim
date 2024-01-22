using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class MakeAutoSave : GameAction
	{
		public override string GetCaption()
		{
			return $"MakeAutoSave(SaveForImport: {SaveForImport})";
		}

		public bool SaveForImport;
	}
}
