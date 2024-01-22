namespace Kingmaker.Designers.EventConditionActionSystem.Actions;

public class StartDialog : GameAction
{
	public override string GetCaption()
	{
		return $"StartDialog({m_Dialogue.Guid.ToString()[..8]}:{m_Dialogue.Name}, {DialogueOwner})";
	}

	public UnitEvaluator DialogueOwner;

	public BlueprintReferenceBase m_Dialogue;

    public BlueprintEvaluator DialogEvaluator;

    public LocalizedString SpeakerName;
}
