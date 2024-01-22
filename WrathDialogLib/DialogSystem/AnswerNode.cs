namespace WrathDialogLib.DialogSystem;

public class AnswerNode : BaseNode
{
    public AnswerNode(string guid, string name) : base(guid, name)
    {

    }

    public string? MythicRequirement { get; set; }
    public string? AlignmentRequirement { get; set; }

    public ShowCheck? ShowCheck { get; set; }

    public override string GetSpeaker()
    {
        return "Player";
    }

    public override bool HasText => !Text?.IsEmptyString() ?? false;
}

public sealed class ShowCheck
{
    public string CheckType { get; private set; }
    public int CheckDC { get; set; }

    public ShowCheck(string checkType, int checkDC)
    {
        CheckType = checkType;
        CheckDC = checkDC;
    }

    public override string ToString()
    {
        return $"{CheckType} DC{CheckDC}";
    }
}
