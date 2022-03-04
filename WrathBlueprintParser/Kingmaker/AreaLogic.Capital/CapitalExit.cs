using System;
using Kingmaker.Blueprints;
using Kingmaker.Designers;
using Kingmaker.ElementsSystem;
using UnityEngine;

namespace Kingmaker.AreaLogic.Capital
{
	public class CapitalExit : GameAction
	{
		public override string GetCaption()
		{
			return $"CapitalExit({m_Destination}, {AutoSaveMode})";
		}

		public BlueprintReferenceBase m_Destination;

		public string AutoSaveMode;
	}
}
