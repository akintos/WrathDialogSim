using Kingmaker.ElementsSystem;
using Newtonsoft.Json;
using System.IO;
using WrathDialogLib;
using WrathDialogLib.DialogSystem;

namespace WrathBlueprintParser;

/// <summary>
/// Traverse through each dialog tree and generate translation annotation data.
/// </summary>
internal class DialogDataGenerator
{
    private SerializedDialog db;

    private HashSet<string> visitedNodes = new();

    //private DialogData currentDialogData = null;

    //private List<DialogData> result = new();

    //private Dictionary<string, DialogData> dialogMap = new();

    private List<DialogNodeData> nodes = new();

    public DialogDataGenerator(SerializedDialog db)
    {
        this.db = db;
        DialogManager.Instance.LoadDatabase(db);
    }

    public void Run(string outputPath)
    {
        nodes = new();

        foreach (var dialog in db.DialogList)
        {
            VisitNode(dialog);
        }

        foreach (var node in db.GetNodeDict().Values)
        {
            VisitNode(node, unused: true);
        }

        JsonHelper.SerializeJsonAsync(outputPath, nodes).GetAwaiter().GetResult();
    }

    private void VisitNode(BaseNode node, bool unused = false)
    {
        if (visitedNodes.Contains(node.Guid))
            return;

        visitedNodes.Add(node.Guid);

        Dictionary<string, string> commentDict = new();

        if (unused)
        {
            commentDict["Unused"] = "true";
        }
        
        if (node.Dialog?.Get().Type != DialogType.Book)
        {
            commentDict["Speaker"] = node.GetSpeaker();
        }

        if (node.AlignmentShift is not null)
        {
            commentDict["AlignmentShift"] = $"{node.AlignmentShift.Direction} {node.AlignmentShift.Value}";
        }

        if (node is CheckNode chkNode)
        {
            commentDict["CheckType"] = chkNode.CheckType;
            commentDict["CheckDC"] = chkNode.CheckDC.ToString();
        }

        if (node is AnswerNode ansNode)
        {
            if (!string.IsNullOrEmpty(ansNode.MythicRequirement))
            {
                commentDict["MythicRequirement"] = ansNode.MythicRequirement;
            }
            if (!string.IsNullOrEmpty(ansNode.AlignmentRequirement))
            {
                commentDict["AlignmentRequirement"] = ansNode.AlignmentRequirement;
            }
            if (ansNode.ShowCheck is not null)
            {
                commentDict["ShowCheck"] = ansNode.ShowCheck.ToString();
            }
        }

        if (node.Conditions is not null)
        {
            commentDict["Conditions"] = node.Conditions;
        }

        if (node.Comment is not null)
        {
            commentDict["Comment"] = node.Comment;
        }

        var nodeData = new DialogNodeData(node, commentDict);

        nodes.Add(nodeData);

        foreach (var nextNodeRef in node.NextNodes)
        {
            BaseNode nextNode;
            try
            {
                nextNode = nextNodeRef.Get();
            }
            catch (KeyNotFoundException)
            {
                continue;
            }
            VisitNode(nextNode, unused);
        }
    }

    //private sealed record class DialogData
    //{
    //    public string Guid { get; set; }
    //    public string Name { get; set; }
    //    public string Path { get; set; }
    //    public string DefaultSpeaker { get; set; }

    //    public List<DialogNodeData> Strings { get; set; }
    //}

    private sealed record class DialogNodeData
    {
        public DialogNodeData(BaseNode node, Dictionary<string, string> comment)
        {
            if (node.Dialog is not null)
            {
                var dialog = node.Dialog.Get();
                DialogGuid = dialog.Guid;
                DialogName = dialog.Name;
            }

            NodeGuid = node.Guid;
            NodeName = node.Name;
            Comment = comment;
        }

        public string? DialogGuid { get; set; }
        public string? DialogName { get; set; }
        public string NodeGuid { get; set; }
        public string NodeName { get; set; }
        public Dictionary<string, string> Comment { get; set; }
    }
}
