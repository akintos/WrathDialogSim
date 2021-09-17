using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    public class UnitInventory : ItemsCollectionEvaluator
    {

        public override string GetCaption()
        {
            return string.Format("UnitInventory({0})", Unit);
        }

        public UnitEvaluator Unit;
    }
}
