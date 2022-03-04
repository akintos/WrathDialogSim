using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class UnequipAllItems : GameAction
    {
        public override string GetCaption()
        {
            return $"UnequipAllItems({Target}, Destination: {DestinationContainer}, Silet: {Silent})";
        }

        public UnitEvaluator Target;

		public ItemsCollectionEvaluator DestinationContainer;

		public bool Silent;
    }
}
