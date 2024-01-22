namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;

public class CheckPassed : Condition
{
    protected override string GetConditionCaption()
    {
        return string.Format("CheckPassed({0})", m_Check.Guid.ToString()[..8]);
    }

    public BlueprintReferenceBase m_Check;
}
