namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;

public class ConditionalUnitEvaluator : UnitEvaluator
{
    // TODO
    public override string GetCaption()
    {
        return $"ConditionalUnit({m_Default})";
    }

    public ConditionalPair[] m_Units;

    public UnitEvaluator m_Default;

    [Serializable]
    public class ConditionalPair
    {
        public ConditionsChecker Condition;

        public UnitEvaluator Unit;

        public override string ToString()
        {
            return $"if ({Condition}) {{{Unit}}}";
        }
    }
}