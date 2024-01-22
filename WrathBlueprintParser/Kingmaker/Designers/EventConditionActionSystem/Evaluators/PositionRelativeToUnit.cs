namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;

public class PositionRelativeToUnit : PositionEvaluator
{
    public override string GetCaption()
    {
        return string.Format("{0}m from {1}", this.Distance, (this.Unit == null) ? "-null-" : this.Unit.GetCaption());
    }

    public UnitEvaluator Unit;

    public float Distance;

    public float Angle;
}