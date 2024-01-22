namespace WrathDialogLib.DialogSystem;

public class CheckNode : BaseNode
{
    public CheckNode(string guid, string name, string checkType, int checkDc) : base(guid, name)
    {
        CheckType = checkType;
        CheckDC = checkDc;
    }

    public string CheckType { get; set; }
    public int CheckDC { get; set; }

    public override bool HasText => true;
    public override string? AlternativeText => $"Check node {CheckType} DC = {CheckDC}";

    public NodeRefBase Success => NextNodes[0];
    public NodeRefBase Fail => NextNodes[1];
}
