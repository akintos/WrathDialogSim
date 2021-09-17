using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class CombineToGroup : GameAction
	{
		public override string GetCaption()
		{
			return string.Format("CombineToGroup({0}, {1})", this.TargetUnit, this.GroupHolder);
		}

		public UnitEvaluator TargetUnit;

		public UnitEvaluator GroupHolder;
	}
}
