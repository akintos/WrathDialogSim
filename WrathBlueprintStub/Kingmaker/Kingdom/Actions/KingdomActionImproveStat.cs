using System;
using Kingmaker.Kingdom.Blueprints;

namespace Kingmaker.Kingdom.Actions
{
    public class KingdomActionImproveStat : KingdomAction
    {
        public override string GetCaption()
        {
            return $"KingdomActionImproveStat({StatType})";
        }

        public string StatType;
    }
}
