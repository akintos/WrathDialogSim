using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    public class CompanionInParty : UnitEvaluator
    {
        public override string GetCaption()
        {
            return $"CompanionInParty({m_Companion})";
        }

        public BlueprintUnitReference m_Companion;

        public bool IncludeRemote;
        public bool IncludeExCompanions;
        public bool IncludeDettached;
    }
}
