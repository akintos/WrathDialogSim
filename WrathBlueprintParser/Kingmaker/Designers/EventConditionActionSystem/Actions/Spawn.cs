using System;
using System.Linq;
using System.Collections.Generic;
using Kingmaker.Blueprints;

using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class Spawn : GameAction
	{
		public override string GetCaption()
		{
			string text = string.Join(", ", Spawners.Select(x => x.EntityNameInEditor));
			return $"Spawn(Spawners: [{text}], Actions: {ActionsOnSpawn.LambdaFormat()}";
		}

		public EntityReference[] Spawners;

		public ActionList ActionsOnSpawn;
	}
}
