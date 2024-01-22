using System;

namespace Kingmaker.Blueprints.Loot
{
    [Serializable]
    public class LootEntry
    {
        public BlueprintReferenceBase m_Item;

        public int Count = 1;

        public override string ToString() => $"{m_Item} x {Count}";
    }
}
