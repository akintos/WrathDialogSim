namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;

public class NearestPosition : PositionEvaluator
{
    public override string GetCaption()
    {
        return string.Format("Nearest position from {0}", this.Center);
    }

    public ConditionalPair[] m_Positions;

    public PositionEvaluator Center;

    [Serializable]
    public class ConditionalPair
    {
        public ConditionsChecker Condition;

        public PositionEvaluator Position;
    }
}