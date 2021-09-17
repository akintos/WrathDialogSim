using System;
using System.Linq;

using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RandomAction : GameAction
	{
		public override string GetCaption()
		{
			var actions = string.Join(", ", Actions.Select(x => "(" + x.ToString() + ")"));
			return $"RandomAction({actions})";
		}

		public ActionAndWeight[] Actions;
	}
}
