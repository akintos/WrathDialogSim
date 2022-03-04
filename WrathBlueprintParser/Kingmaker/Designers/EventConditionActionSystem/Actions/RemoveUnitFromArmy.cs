using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RemoveUnitFromArmy : GameAction
	{
		public override string GetCaption()
		{
			return $"RemoveUnitFromArmy({m_Armies}, {m_UnitToRemove}, {m_Mode})";
		}

		public ArmiesEvaluator m_Armies;
		public RemoveUnitFromArmyMode m_Mode;
		public BlueprintUnitReference m_UnitToRemove;

		public enum RemoveUnitFromArmyMode
		{
			Single,
			Multiple,
			Every
		}
	}
}
