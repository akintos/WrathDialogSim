namespace Kingmaker.ElementsSystem;

public class EtudeBlueprint : BlueprintEvaluator
{
    public override string GetCaption()
    {
        return m_Value.Name;
    }

    public BlueprintReferenceBase m_Value;
}