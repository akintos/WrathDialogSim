namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;
public class Subtraction : IntEvaluator
{
    public override string GetCaption()
    {
        return $"{FirstValue} - {SecondValue}";
    }

    public IntEvaluator FirstValue;

    public IntEvaluator SecondValue;
}