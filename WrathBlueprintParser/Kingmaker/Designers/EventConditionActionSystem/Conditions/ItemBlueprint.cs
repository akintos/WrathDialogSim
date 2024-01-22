namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;

public class ItemBlueprint : Condition
{
    protected override string GetConditionCaption()
    {
        return $"ItemBlueprint({Item}, {Blueprint})";
    }

    public ItemEvaluator Item;

    public BlueprintItemReference Blueprint;
}