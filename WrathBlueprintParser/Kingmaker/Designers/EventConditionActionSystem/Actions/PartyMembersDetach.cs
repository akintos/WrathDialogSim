using System;
using System.Linq;
using Kingmaker.Blueprints;

using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class PartyMembersDetach : GameAction
	{
		public override string GetCaption()
		{
			if (m_DetachAllExcept.Length <= 0)
			{
				return "PartyMembersDetach()";
			}
			return "PartyMembersDetach(Except: " + string.Join(", ", from u in this.m_DetachAllExcept select u.ToString()) + ")";
		}

		public BlueprintUnitReference[] m_DetachAllExcept = new BlueprintUnitReference[0];
	}
}
