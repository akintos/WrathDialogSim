using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class TranslocatePlayer : GameAction
	{
		public override string GetCaption()
		{
			return $"TransolcatePlayer({transolcatePosition})";
		}

		public EntityReference transolcatePosition;

		public bool ByFormationAndWithPets;

		public bool ScrollCameraToPlayer = true;
	}
}
