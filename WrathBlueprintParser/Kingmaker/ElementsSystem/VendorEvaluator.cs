namespace Kingmaker.ElementsSystem;

public class VendorEvaluator : Evaluator
{
    public override string GetCaption()
    {
        return $"VendorEvaluator({m_VendorEvaluator})";
    }

    public UnitEvaluator m_VendorEvaluator;
}