using System;
using System.Linq;
using System.Collections.Generic;
using Kingmaker.Blueprints;

using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SpawnBySummonPool : GameAction
	{
		public override string GetCaption()
		{
			return $"SpawnBySummonPool({m_Pool}, Actions: {ActionsOnSpawn.LambdaFormat()})";
		}

		public BlueprintReferenceBase m_Pool;

		public ActionList ActionsOnSpawn;
	}
}
