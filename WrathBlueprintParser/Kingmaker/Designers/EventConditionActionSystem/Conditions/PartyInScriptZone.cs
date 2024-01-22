namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;

public class PartyInScriptZone : Condition
{
    protected override string GetConditionCaption()
    {
        return $"PartyInScriptZone({m_Check}, {m_ScriptZone})";
    }

    public CheckType m_Check;

    public EntityReference m_ScriptZone;

    public enum CheckType
    {
        SomeoneInParty,
        EveryoneParty,
        MainCharacter
    }
}