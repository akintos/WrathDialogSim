namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;
public class IsDLCEnabled : Condition
{
    protected override string GetConditionCaption()
    {
        return $"IsDLCEnabled({m_BlueprintDlcReward})";
    }

    public BlueprintReferenceBase m_BlueprintDlcReward;
}