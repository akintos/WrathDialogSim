using Kingmaker.ElementsSystem;
using Kingmaker.Enums;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    public class PetEvaluator : UnitEvaluator
    {
        public override string GetCaption()
        {
            return $"Pet({Master}, {PetType})";
        }

        public UnitEvaluator Master;

        public PetType PetType;
    }
}
