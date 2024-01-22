using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions;

public class PlayCutscene : GameAction
{
    public override string GetCaption()
    {
        return $"PlayCutscene({m_Cutscene})";
    }

    public BlueprintReferenceBase m_Cutscene;

    public ParametrizedContextSetter Parameters;
}
