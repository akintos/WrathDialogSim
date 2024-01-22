using System;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SwitchInteraction : GameAction
	{
		public override string GetCaption()
		{
			return $"SwitchInteraction({MapObject}, Enable: {EnableIfAlreadyDisabled}, Disable: {DisableIfAlreadyEnabled})";
		}

		public MapObjectEvaluator MapObject;

		public bool EnableIfAlreadyDisabled;

		public bool DisableIfAlreadyEnabled;
	}
}
