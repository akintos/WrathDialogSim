using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Newtonsoft.Json;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SpawnByUnitGroup : GameAction
	{
		public override string GetCaption()
		{
			return $"SpawnByUnitGroup({Group}, ActionsOnSpawn: {{{ActionsOnSpawn}}})";
		}

		public EntityReference Group;

		public ActionList ActionsOnSpawn;
	}
}
