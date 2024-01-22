using System;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ChangeAlignment : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("ChangeAlignment({0}, {1})", Unit, Alignment);
		}

		public UnitEvaluator Unit;

		public Alignment Alignment;
	}
}
