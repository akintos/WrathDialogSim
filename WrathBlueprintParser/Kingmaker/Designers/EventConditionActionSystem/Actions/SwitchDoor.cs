using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SwitchDoor : GameAction
	{
		public override string GetCaption()
		{
			return $"SwitchDoor({Door}, Unlock: {UnlockIfLocked}, Close: {CloseIfAlreadyOpen}, Open: {OpenIfAlreadyClosed})";
		}

		public MapObjectEvaluator Door;

		public bool UnlockIfLocked;
		public bool CloseIfAlreadyOpen;
		public bool OpenIfAlreadyClosed;
	}
}
