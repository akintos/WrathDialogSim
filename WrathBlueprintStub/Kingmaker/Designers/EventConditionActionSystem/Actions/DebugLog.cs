using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class DebugLog : GameAction
	{
		public override string GetCaption()
		{
			return $"DebugLog({Log})";
		}


		public string Log;
	}
}
