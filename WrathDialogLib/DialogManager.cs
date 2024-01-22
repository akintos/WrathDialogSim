using WrathDialogLib.DialogSystem;

namespace WrathDialogLib;

public class DialogManager
{
    private static DialogManager? _instance;
    public static DialogManager Instance => _instance ??= new DialogManager();

    private Dictionary<string, BaseNode> Nodes = new Dictionary<string, BaseNode>();

    public static bool TryGetNode(string nodeId, out BaseNode node)
    {
        if (nodeId.Length > 8)
            nodeId = nodeId.Substring(0, 8);

        return Instance.Nodes.TryGetValue(nodeId, out node);
    }

    public static BaseNode GetNode(string nodeId)
    {
        if (nodeId.Length > 8)
            nodeId = nodeId.Substring(0, 8);

        return Instance.Nodes[nodeId];
    }

    private DialogManager() { }

    public async Task LoadDatabase(string path)
    {
        var serializedDb = await SerializedDialog.DeserializeAsync(path);
        Nodes = serializedDb.GetNodeDict();
    }

    public void LoadDatabase(SerializedDialog db)
    {
        Nodes = db.GetNodeDict();
    }
}
