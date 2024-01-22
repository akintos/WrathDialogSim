namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;
public class UnitFromSpawnerIsDead : Condition
{
    protected override string GetConditionCaption()
    {
        return $"UnitFromSpawnerIsDead({Target})";
    }

    public EntityReference Target;
}