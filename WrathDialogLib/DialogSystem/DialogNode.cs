namespace WrathDialogLib.DialogSystem;

public class DialogNode : BaseNode
{
    public string Path { get; set; }
    public string? DefaultSpeaker { get; set; }

    public DialogType Type { get; set; }

    public DialogNode(string guid, string name, string path) : base(guid, name)
    {
        Path = path;
    }

    public override string? AlternativeText => Path;
}

public enum DialogType
{
    Common,
    Book,
    Interchapter,
    Epilogue,
}
