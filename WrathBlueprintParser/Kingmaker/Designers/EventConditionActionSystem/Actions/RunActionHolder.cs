using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class RunActionHolder : GameAction
	{
		public override string GetCaption()
		{
			return $"RunActionHolder({Holder}, {Comment})";
		}

		public BlueprintReferenceBase Holder;
		public string Comment;
	}
}
