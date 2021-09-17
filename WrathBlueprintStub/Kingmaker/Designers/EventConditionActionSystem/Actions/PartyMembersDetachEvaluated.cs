using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class PartyMembersDetachEvaluated : GameAction
	{
		public override string GetCaption()
		{
			if (DetachThese == null || DetachThese.Length == 0)
			{
				return "PartyMembersDetachEvaluated(Manual)";
			}
			var detach = string.Join(", ", DetachThese.Select(x => x.ToString()));
			return $"PartyMembersDetachEvaluated(Detach: {detach})";
		}

		public UnitEvaluator[] DetachThese;
	}
}
