using System;
using Kingmaker.ElementsSystem;
using Kingmaker.Kingdom.Blueprints;

namespace Kingmaker.Kingdom.Actions
{
	public class KingdomActionModifyStats : KingdomAction
	{
		public override string GetCaption()
		{
			return $"KingdomActionModifyStats({Changes.ToStringWithPrefix(" ")})";
		}

		public bool IncludeInEventStats = true;

		public KingdomStats.Changes Changes;
	}
}
