using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ShowMultiEntrance : GameAction
	{
		public override string GetCaption()
		{
			return $"ShowMultiEntrance({m_Map})";
		}

		public BlueprintReferenceBase m_Map;
	}
}
