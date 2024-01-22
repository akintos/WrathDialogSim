namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;

public class IsUnitMythicLevel : Condition
{
    protected override string GetConditionCaption()
    {
        return string.Format("IsUnitMythicLevel({0}{1}{2})", new object[]
        {
            CheckMinLevel ? $"{MinLevel} ≤ " : "",
            Unit,
            CheckMaxLevel ? $" ≤ {MaxLevel}" : ""
        });
    }

    public UnitEvaluator Unit;

    public bool CheckMinLevel;

    public IntEvaluator MinLevel;

    public bool CheckMaxLevel;

    public IntEvaluator MaxLevel;
}