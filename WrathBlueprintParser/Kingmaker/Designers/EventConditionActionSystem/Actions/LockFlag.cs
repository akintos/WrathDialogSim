using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class LockFlag : GameAction
	{
		public override string GetCaption()
		{
			return $"LockFlag({m_Flag})";
		}

		public BlueprintReferenceBase m_Flag;
	}
}
