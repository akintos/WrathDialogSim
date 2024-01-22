namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;
public class ConditionalPositionEvaluator : PositionEvaluator
{
    public override string GetCaption()
    {
        return $"ConditionalPositionEvaluator({m_Positions.ToCommaSeparatedString()}, Default: {m_Default})";
    }

    public ConditionalPair[] m_Positions;

    public PositionEvaluator m_Default;

    [Serializable]
    public class ConditionalPair
    {
        public ConditionsChecker Condition;

        public PositionEvaluator Position;
    }
}
