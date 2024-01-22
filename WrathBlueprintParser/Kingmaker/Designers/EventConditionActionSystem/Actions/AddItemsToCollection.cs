using System;
using System.Linq;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Loot;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class AddItemsToCollection : GameAction
    {
        public override string GetCaption()
        {
            var loots = string.Join(", ", Loot.Select(x => x.ToString()));
            return $"AddItemsToCollection({ItemsCollection}, {loots})";
        }

        public ItemsCollectionEvaluator ItemsCollection;

        public bool UseBlueprintUnitLoot;

        public List<LootEntry> Loot;

        public bool Silent;

        public bool Identify;
    }
}
