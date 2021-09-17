using System;

using Kingmaker.ElementsSystem;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Alignments;
namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class LockAlignment : GameAction
	{
		public override string GetCaption()
		{
			return $"LockAlignment({Unit}, {TargetAlignment}, Mask: {AlignmentMask})";
		}

		public UnitEvaluator Unit;

		public AlignmentMaskType AlignmentMask;
		public Alignment TargetAlignment;
	}
}
