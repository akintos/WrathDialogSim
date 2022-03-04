using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Kingdom.Blueprints
{
	public class AddCrusadeResources : GameAction
	{
		public override string GetCaption()
		{
			return $"AddCrusadeResources({_resourcesAmount})";
		}

		public KingdomResourcesAmount _resourcesAmount;
	}
}
