using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Sound;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SetSoundState : GameAction
	{
		public override string GetCaption()
		{
			return $"SetSoundState({m_State.Group}, {m_State.Value})";
		}

		public AkStateReference m_State;
	}
}
