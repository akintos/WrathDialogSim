using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class UnlockLocation : GameAction
	{
		public override string GetCaption()
		{
			return $"UnlockLocation({m_Location}, Hide: {HideInstead}, Fake: {FakeDescription})";
		}

		public BlueprintReferenceBase m_Location;

		public bool FakeDescription;
		public bool HideInstead;
	}
}
