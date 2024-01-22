using WrathDialogLib;
using WrathDialogLib.DialogSystem;

using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.AreaLogic.Cutscenes.Commands;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;
using Kingmaker.DialogSystem;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using Kingmaker.Designers.EventConditionActionSystem.NamedParameters;

namespace WrathBlueprintParser;

public class KingmakerBlueprintConverter
{
    private readonly StringBuilder sb = new();

    private readonly Dictionary<string, BaseNode> NodeDict = new();
    private readonly List<DialogNode> DialogList = new();

    internal Dictionary<Guid, string> DialogDefaultSpeakers { get; set; } = new();

    public KingmakerBlueprintConverter()
    {

    }

    public SerializedDialog ConvertBlueprints(KingmakerResourceManager mgr)
    {
        var bpTypeLookup = mgr.BlueprintDict.Values.ToLookup(x => x.GetType());

        foreach (var bp in bpTypeLookup[typeof(BlueprintAnswer)])
        {
            ConvertBlueprintAnswer(bp as BlueprintAnswer);
        }

        foreach (var bp in bpTypeLookup[typeof(BlueprintAnswersList)])
        {
            ConvertBlueprintAnswersList(bp as BlueprintAnswersList);
        }

        foreach (var bp in bpTypeLookup[typeof(BlueprintCue)])
        {
            ConvertBlueprintCue(bp as BlueprintCue);
        }

        foreach (var bp in bpTypeLookup[typeof(BlueprintCheck)])
        {
            ConvertBlueprintCheck(bp as BlueprintCheck);
        }

        foreach (var bp in bpTypeLookup[typeof(BlueprintBookPage)])
        {
            ConvertBlueprintBookPage(bp as BlueprintBookPage);
        }

        foreach (var bp in bpTypeLookup[typeof(BlueprintSequenceExit)])
        {
            ConvertBlueprintSequenceExit(bp as BlueprintSequenceExit);
        }

        foreach (var bp in bpTypeLookup[typeof(BlueprintCueSequence)])
        {
            ConvertBlueprintCueSequence(bp as BlueprintCueSequence);
        }

        Dictionary<string, string> directoryDialogMap = new();

        foreach (var bp in bpTypeLookup[typeof(BlueprintDialog)])
        {
            string directory = Path.GetDirectoryName(bp.Path);

            if (directoryDialogMap.TryGetValue(directory, out string dialogGuid))
            {
                directoryDialogMap[directory] = null;
            }
            else
            {
                directoryDialogMap[directory] = bp.Guid;
            }

            ConvertBlueprintDialog(bp as BlueprintDialog);
        }

        foreach (var dialog in DialogList)
        {
            var dialogRef = dialog.ToReference();
            foreach (var childRef in dialog.NextNodes)
            {
                if (NodeDict.TryGetValue(childRef.Guid, out var nextNode) && nextNode.Dialog == null)
                {
                    SetDialogNode(nextNode, dialogRef: dialogRef, prevNodeRef: dialogRef);
                }
                else
                {
                    // Console.WriteLine(childRef.Guid);
                }
            }
        }

        int orphanCount = 0;

        var noDialog = NodeDict.Values.Where(x => x.Dialog == null && x.GetType() != typeof(DialogNode)).ToList();
        foreach (var node in noDialog)
        {
            SimpleBlueprint nodeBp = mgr.GetBlueprint(node.Guid);

            string directory = Path.GetDirectoryName(nodeBp.Path);

            if (directoryDialogMap.TryGetValue(directory, out string dialogGuid) && dialogGuid != null)
            {
                node.Dialog = new NodeRef<DialogNode>(dialogGuid);
            }
            else
            {
                orphanCount++;
            }
        }

        Console.WriteLine($"Orphan nodes: {orphanCount}");

        var db = new SerializedDialog();

        var nodeTypeLookup = NodeDict.Values.ToLookup(x => x.GetType());

        foreach (var node in NodeDict.Values)
        {
            if (!string.IsNullOrEmpty(node.Comment))
            {
                node.Comment = node.Comment.Replace("\r\n", "\n").TrimEnd();
            }
            if (!string.IsNullOrEmpty(node.Conditions))
            {
                node.Conditions = node.Conditions.Replace("\r\n", "\n").TrimEnd();
            }
        }
        
        foreach (var nodeGroup in nodeTypeLookup)
        {
            var listField = typeof(SerializedDialog).GetField(nodeGroup.Key.Name.Replace("Node", "") + "List");
            var list = listField.GetValue(db);
            var addMethod = list.GetType().GetMethod("Add");
            foreach (var node in nodeGroup)
            {
                addMethod.Invoke(list, new object[] { node });
            }
        }

        return db;
    }

    private void SetDialogNode(BaseNode node, NodeRef<DialogNode> dialogRef, NodeRefBase prevNodeRef)
    {
        node.Dialog = dialogRef;
        node.PrevNode = prevNodeRef;

        var nodeRef = node.ToReference();

        foreach (var childRef in node.NextNodes)
        {
            if (NodeDict.TryGetValue(childRef.Guid, out var nextNode))
            {
                if (nextNode.Dialog == null)
                {
                    SetDialogNode(NodeDict[childRef.Guid], dialogRef, nodeRef);
                }
            }
            else
            {
                Console.WriteLine(childRef.Guid);
            }
        }
    }

    private void ConvertBlueprintAnswer(BlueprintAnswer bp)
    {
        if (bp.Text.Key == null)
            return;

        AnswerNode node = new(bp.Guid, bp.Name);

        node.Text = bp.Text;
        node.AlignmentShift = (AlignmentShift)bp.AlignmentShift;

        node.NextNodes = bp.NextCue.Cues.ToNodeRefArray();

        // Conditions
        sb.Clear();

        if (bp.ShowConditions.Conditions.Length != 0)
            sb.Append("ShowConditions = ").Append(bp.ShowConditions).AppendLine();

        if (bp.SelectConditions.Conditions.Length != 0)
            sb.Append("SelectConditions = ").Append(bp.SelectConditions).AppendLine();

        if (sb.Length > 0)
            node.Conditions = sb.ToString();

        // Comment
        sb.Clear();

        if (bp.Experience != DialogExperience.NoExperience)
            sb.Append("Experience = ").Append(bp.Experience).AppendLine();

        if (bp.ShowCheck.Type != StatType.Unknown)
            sb.Append("ShowCheck = ").Append(bp.ShowCheck).AppendLine();

        if (bp.OnSelect.Actions.Length != 0)
            sb.Append("OnSelect = ").Append(bp.OnSelect).AppendLine();

        if (bp.FakeChecks.Length != 0)
            sb.Append("FakeChecks = ").Append(string.Join(", ", bp.FakeChecks.Select(x => x.ToString()))).AppendLine();

        if (sb.Length > 0)
            node.Comment = sb.ToString();

        if (bp.ShowCheck.Type != StatType.Unknown)
            node.ShowCheck = new WrathDialogLib.DialogSystem.ShowCheck(bp.ShowCheck.Type.ToString(), bp.ShowCheck.DC);

        node.MythicRequirement = ConvertMythicRequirement(bp.MythicRequirement);
        node.AlignmentRequirement = ConvertAlignmentRequirement(bp.AlignmentRequirement);

        NodeDict[node.Guid] = node;
    }

    private void ConvertBlueprintAnswersList(BlueprintAnswersList bp)
    {
        AnswerNode node = new(bp.Guid, bp.Name);

        node.MythicRequirement = ConvertMythicRequirement(bp.MythicRequirement);
        node.AlignmentRequirement = ConvertAlignmentRequirement(bp.AlignmentRequirement);

        node.NextNodes = bp.Answers.ToNodeRefArray();

        NodeDict[node.Guid] = node;
    }

    private void ConvertBlueprintCue(BlueprintCue bp)
    {
        string speaker;

        if (bp.Speaker?.m_SpeakerPortrait?.Name == "Finnean_Companion")
        {
            speaker = "Finnean";
        }
        else
        {
            speaker = bp.Speaker.GetLocalizedName();
        }

        CueNode node = new(bp.Guid, bp.Name, speaker, bp.Text)
        {
            AlignmentShift = bp.AlignmentShift
        };

        var nextNodeList = new List<NodeRefBase>();
        nextNodeList.AddRange(bp.Continue.Cues.ToNodeRefArray());
        nextNodeList.AddRange(bp.Answers.ToNodeRefList());

        var nextRefList = Enumerable.Concat<BlueprintReferenceBase>(bp.Continue.Cues, bp.Answers).ToList();

        if (nextRefList.Count == 2)
        {
            var node1 = nextRefList[0].Get();
            var node2 = nextRefList[1].Get();

            BlueprintCueSequence seq = null;
            SimpleBlueprint otherNode = null;

            if (node1 is BlueprintCueSequence seq1)
            {
                seq = seq1;
                otherNode = node2;
            }
            else if (node2 is BlueprintCueSequence seq2)
            {
                seq = seq2;
                otherNode = node1;
            }

            if (seq != null)
            {
                var exit = seq.m_Exit.Get();
                var exitNextNode = Enumerable.Concat<BlueprintReferenceBase>(exit.Continue.Cues, exit.Answers).ToList();
                if (exitNextNode.Count == 1 && exitNextNode[0].Guid.ToString("N") == otherNode.Guid)
                {
                    nextRefList = new List<BlueprintReferenceBase>() { new BlueprintReferenceBase() { Guid = new Guid(seq.Guid) } };
                }
            }
        }

        node.NextNodes = nextRefList.ToNodeRefArray();

        { // Comment
            sb.Clear();

            if (bp.Experience != DialogExperience.NoExperience)
                sb.Append("Experience = ").Append(bp.Experience).AppendLine();

            if (!bp.OnShow.IsEmpty)
                sb.Append("OnShow = ").Append(bp.OnShow).AppendLine();

            if (!bp.OnStop.IsEmpty)
                sb.Append("OnStop = ").Append(bp.OnStop).AppendLine();

            if (sb.Length > 0)
                node.Comment = sb.ToString();
        }

        if (!bp.Conditions.IsEmpty)
            node.Conditions = bp.Conditions.ToString();

        NodeDict[node.Guid] = node;
    }

    private void ConvertBlueprintCheck(BlueprintCheck bp)
    {
        if (bp.m_Success is null || bp.m_Fail is null)
            return;

        CheckNode node = new(bp.Guid, bp.Name, bp.Type.ToString(), bp.DC);

        node.Comment = $"Experience = {bp.Experience}\n{bp.GetDCModifierText()}";
        node.NextNodes = new NodeRefBase[] { bp.m_Success.ToNodeRef(), bp.m_Fail.ToNodeRef() };

        NodeDict[node.Guid] = node;
    }

    private void ConvertBlueprintBookPage(BlueprintBookPage bp)
    {
        LinkNode bookPageNode = new(bp.Guid, bp.Name);
        bookPageNode.Text = bp.Title;

        BaseNode currentNode = bookPageNode;

        foreach (var cueReference in bp.Cues)
        {
            BaseNode cueNode = NodeDict[cueReference.Guid.ToString("N")];
            currentNode.NextNodes = new NodeRefBase[] { cueNode.ToReference() };
            currentNode = cueNode;
        }

        currentNode.NextNodes = bp.Answers.ToNodeRefArray();

        if (!bp.OnShow.IsEmpty)
            bookPageNode.Comment = $"OnShow = {bp.OnShow}\n";

        NodeDict[bookPageNode.Guid] = bookPageNode;
    }

    private void ConvertBlueprintSequenceExit(BlueprintSequenceExit bp)
    {
        LinkNode node = new(bp.Guid, bp.Name);

        var nextNodeList = new List<NodeRefBase>();
        nextNodeList.AddRange(bp.Answers.ToNodeRefList());
        nextNodeList.AddRange(bp.Continue.Cues.ToNodeRefList());

        node.NextNodes = nextNodeList.ToArray();

        NodeDict[node.Guid] = node;
    }

    private void ConvertBlueprintCueSequence(BlueprintCueSequence bp)
    {
        if (bp.Cues.Count == 0)
            return;

        LinkNode sequenceStartNode = new(bp.Guid, bp.Name);

        NodeDict[sequenceStartNode.Guid] = sequenceStartNode;
        List<BaseNode> currentNodeList = new() { sequenceStartNode };

        foreach (var cueReference in bp.Cues)
        {
            BaseNode cueNode = NodeDict[cueReference.Guid.ToString("N")];
            foreach (var currentNode in currentNodeList)
            {
                currentNode.NextNodes = new NodeRefBase[] { cueNode.ToReference() };
            }

            if (cueNode.NextNodes.Length == 0)
            {
                currentNodeList = new() { cueNode };
            }
            else
            {
                var leafNodes = new DialogTreeSearch().GetLeafNodes(cueReference);
                currentNodeList = leafNodes.Select(x => NodeDict[x.Guid.ToString("N")]).ToList();
            }
        }

        if (bp.m_Exit is not null)
        {
            foreach (var currentNode in currentNodeList)
            {
                currentNode.NextNodes = new NodeRefBase[] { bp.m_Exit.ToNodeRef() };
            }
        }
    }

    private void ConvertBlueprintDialog(BlueprintDialog bp)
    {
        DialogNode node = new(bp.Guid, bp.Name, bp.Path);

        node.NextNodes = bp.FirstCue.Cues.ToNodeRefArray();

        sb.Clear();

        sb.Append($"SelectionStrategy = {bp.FirstCue.Strategy}\n");

        if (!bp.Conditions.IsEmpty)
            sb.Append("Conditions = ").Append(bp.Conditions.ToString()).AppendLine();

        if (!bp.StartActions.IsEmpty)
            sb.Append("StartActions = ").Append(bp.StartActions.ToString()).AppendLine();

        if (!bp.FinishActions.IsEmpty)
            sb.Append("FinishActions = ").Append(bp.FinishActions.ToString()).AppendLine();

        if (!bp.ReplaceActions.IsEmpty)
            sb.Append("ReplaceActions = ").Append(bp.ReplaceActions.ToString()).AppendLine();

        node.Comment = sb.ToString();

        node.Type = (WrathDialogLib.DialogSystem.DialogType)bp.Type;

        if (DialogDefaultSpeakers.TryGetValue(new Guid(node.Guid), out string speaker))
        {
            node.DefaultSpeaker = speaker;
        }

        NodeDict[node.Guid] = node;
        DialogList.Add(node);
    }

    private static string? ConvertMythicRequirement(Mythic mythicRequirement)
    {
        if (mythicRequirement == Mythic.None)
            return null;
        return mythicRequirement.ToString();
    }

    private static string? ConvertAlignmentRequirement(AlignmentComponent alignmentRequirement)
    {
        if (alignmentRequirement == AlignmentComponent.None)
            return null;
        return alignmentRequirement.ToString();
    }
}
