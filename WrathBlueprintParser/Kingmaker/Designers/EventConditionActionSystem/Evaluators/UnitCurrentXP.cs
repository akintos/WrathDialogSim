namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;
public class UnitCurrentXP : IntEvaluator
{

    public override string GetCaption()
    {
        return "UnitCurrentXP()";
    }

    public UnitEvaluator Unit;
}