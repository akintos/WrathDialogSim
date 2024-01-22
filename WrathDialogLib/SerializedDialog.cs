using WrathDialogLib.DialogSystem;

namespace WrathDialogLib;

public class SerializedDialog
{
    public List<DialogNode> DialogList = new();

    public List<AnswerNode> AnswerList = new();

    public List<CueNode> CueList = new();

    public List<CheckNode> CheckList = new();

    public List<LinkNode> LinkList = new();

    private Dictionary<string, BaseNode>? nodeDictCache = null;

    public Dictionary<string, BaseNode> GetNodeDict()
    {
        return nodeDictCache ??= Enumerable.Concat<BaseNode>(DialogList, AnswerList)
                                           .Concat(CueList)
                                           .Concat(CheckList)
                                           .Concat(LinkList)
                                           .ToDictionary(x => x.Guid.Substring(0, 8));
    }

    public static async Task<SerializedDialog> DeserializeAsync(string path)
    {
        return await JsonHelper.DeserializeJsonAsync<SerializedDialog>(path);
    }

    public async Task SerializeAsync(string path)
    {
        await JsonHelper.SerializeJsonAsync(path, this);
    }
}
