using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class Unrecruit : GameAction
	{
		public override string GetCaption()
		{
			return $"Unrecruit({m_CompanionBlueprint}, OnUnrecruit: {{{OnUnrecruit}}})";
		}

		public BlueprintUnitReference m_CompanionBlueprint;

		public ActionList OnUnrecruit;
	}
}
