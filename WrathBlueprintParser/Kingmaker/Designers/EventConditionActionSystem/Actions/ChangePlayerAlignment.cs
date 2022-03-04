using System;
using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Alignments;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ChangePlayerAlignment : GameAction
	{
		public override string GetCaption()
		{
			return $"ChangePlayerAlignment({TargetAlignment}, {CanUnlockAlignment})";
		}

		public Alignment TargetAlignment;

		public bool CanUnlockAlignment;
	}
}
