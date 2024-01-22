using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Tutorial.Actions
{
	public class ShowNewTutorial : GameAction
	{
		public override string GetCaption()
		{
			return $"ShowNewTutorial({m_Tutorial})";
		}

		public BlueprintReferenceBase m_Tutorial;
	}
}
