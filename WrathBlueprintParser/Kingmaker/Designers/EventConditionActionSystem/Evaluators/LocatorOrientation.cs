namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;

public class LocatorOrientation : FloatEvaluator
{
    public override string GetCaption()
    {
        return $"LocatorOrientation({LocatorEval.GetCaption()}, {Locator})";
    }

    public LocatorEvaluator LocatorEval;

    public EntityReference Locator;
}