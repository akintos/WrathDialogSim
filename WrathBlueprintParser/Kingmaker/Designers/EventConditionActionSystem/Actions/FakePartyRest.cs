using System;

using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class FakePartyRest : GameAction
	{
		public override string GetCaption()
		{
			if (!m_Immediate)
			{
				return "FakePartyRest()";
			}
			return "FakePartyRest(Immediate)";
		}

		public bool m_Immediate;
	}
}
