using System;
using Kingmaker.Blueprints;

namespace Kingmaker.ElementsSystem
{
	[Serializable]
	public class IsleEvaluator : Evaluator
	{
		public override string GetCaption()
		{
			return this.Locator.ToString();
		}

		public EntityReference Locator;
	}
}
