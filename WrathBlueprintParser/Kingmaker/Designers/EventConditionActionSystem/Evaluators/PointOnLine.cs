using System.Numerics;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;
public class PointOnLine : PositionEvaluator
{
    public override string GetCaption()
    {
        return string.Format("Point on line from {0} to {1} at distance {2}", this.StartPosition, this.DirectionPoint, this.Distance);
    }

    public PositionEvaluator StartPosition;

    public PositionEvaluator DirectionPoint;

    public float Distance;
}