namespace WrathDialogLib.DialogSystem;

public class CueNode : BaseNode
{
    public string Speaker;

    public CueNode(string guid, string name, string speaker, LocalizedString text) : base(guid, name)
    {
        Speaker = speaker;
        Text = text;
    }

    public override string GetSpeaker()
    {
        return Speaker ?? Dialog?.Get().DefaultSpeaker ?? "UNKNOWN";
    }
}
