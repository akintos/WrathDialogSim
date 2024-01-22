namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;
public class Addition : IntEvaluator
{
    public override string GetCaption()
    {
        return $"{FirstValue} + {SecondValue}";
    }

    public IntEvaluator FirstValue;

    public IntEvaluator SecondValue;
}