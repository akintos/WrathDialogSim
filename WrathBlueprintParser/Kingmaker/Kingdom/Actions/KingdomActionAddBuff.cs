using System;
using Kingmaker.Blueprints;
using Kingmaker.Kingdom.Blueprints;

namespace Kingmaker.Kingdom.Actions
{
    public class KingdomActionAddBuff : KingdomAction
    {
        public override string GetCaption()
        {
            return $"KingdomActionAddBuff({m_Blueprint}{(ApplyToRegion ? ", " + m_Region : "")}";
        }

        public BlueprintReferenceBase m_Blueprint;

        public int OverrideDuration;

        // [InfoBox("If true applies buff to region from Region field or (if it's null) to region for context (settlement, event or parent buff)")]
        public bool ApplyToRegion = true;

        // [ShowIf("ApplyToRegion")]
        public BlueprintReferenceBase m_Region;
    }
}
