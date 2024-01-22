namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;

public class UnitVendorInventory : ItemsCollectionEvaluator
{
    public override string GetCaption()
    {
        return $"UnitVendorInventory({Unit})";
    }

    public UnitEvaluator Unit;
}
