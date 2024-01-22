namespace Kingmaker.AreaLogic.Cutscenes.Commands;

public class CommandStartDialog : SimpleBlueprint
{
    public BlueprintDialogReference m_Dialog;

    public UnitEvaluator Speaker;

    public LocalizedString SpeakerName;

    public BlueprintEvaluator DialogEvaluator;
}
