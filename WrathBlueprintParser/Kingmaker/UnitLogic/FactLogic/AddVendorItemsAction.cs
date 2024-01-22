namespace Kingmaker.UnitLogic.FactLogic;

public class AddVendorItemsAction : GameAction
{
    public override string GetCaption()
    {
        return $"AddVendorItems({m_VendorEvaluator}, {m_VendorTable})";
    }

    public VendorEvaluator m_VendorEvaluator;

    public BlueprintReferenceBase m_VendorTable;
}