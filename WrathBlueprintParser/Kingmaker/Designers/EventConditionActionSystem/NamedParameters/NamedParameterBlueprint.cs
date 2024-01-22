namespace Kingmaker.Designers.EventConditionActionSystem.NamedParameters;

[Serializable]
public class NamedParameterBlueprint : BlueprintEvaluator
{
    public override string GetCaption()
    {
        return "P:" + Parameter;
    }

    public string Parameter;
}