using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WrathDialogLib;
using WrathDialogLib.DialogSystem;

using Kingmaker.Blueprints;
using Kingmaker.DialogSystem.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.AreaLogic.Cutscenes.Commands;
using System.Reflection;
using Kingmaker.Designers.EventConditionActionSystem.Evaluators;

namespace Kingmaker
{
    public class KingmakerBlueprintConverter
    {
        private readonly StringBuilder sb = new();

        private readonly Dictionary<string, BaseNode> NodeDict = new();
        private readonly List<DialogNode> DialogList = new();
        private Dictionary<string, string> EntityUnitDict = new();

        public KingmakerBlueprintConverter()
        {

        }

        public void SetEntityUnitData(Dictionary<string, string> data)
        {
            EntityUnitDict = data;
        }

        public SerializedDialog ConvertBlueprints(BlueprintManager mgr)
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

            foreach (var bp in bpTypeLookup[typeof(BlueprintDialog)])
            {
                ConvertBlueprintDialog(bp as BlueprintDialog);
            }

            foreach (var bp in bpTypeLookup[typeof(CommandStartDialog)])
            {
                ProcessCommandStartDialog(bp as CommandStartDialog);
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

            var db = new SerializedDialog();

            var nodeTypeLookup = NodeDict.Values.ToLookup(x => x.GetType());

            foreach (var node in NodeDict.Values)
            {
                if (!string.IsNullOrEmpty(node.Comment))
                {
                    node.Comment = node.Comment.Replace("\r\n", "\n").TrimEnd();
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
            if (bp.Text.Guid == default || string.IsNullOrEmpty(bp.Text.Value))
                return;

            AnswerNode node = new();

            node.Guid = bp.Guid;
            node.Name = bp.Name;

            node.Text = bp.Text;
            node.AlignmentShift = (AlignmentShift)bp.AlignmentShift;

            node.NextNodes = bp.NextCue.Cues.ToNodeRefArray();

            sb.Clear();

            if (bp.Experience != DialogSystem.DialogExperience.NoExperience)
                sb.Append("Experience = ").Append(bp.Experience).AppendLine();

            if (bp.ShowCheck.Type != StatType.Unknown)
                sb.Append("ShowCheck = ").Append(bp.ShowCheck).AppendLine();

            if (bp.ShowConditions.Conditions.Length != 0)
                sb.Append("ShowConditions = ").Append(bp.ShowConditions).AppendLine();

            if (bp.SelectConditions.Conditions.Length != 0)
                sb.Append("SelectConditions = ").Append(bp.SelectConditions).AppendLine();

            if (bp.OnSelect.Actions.Length != 0)
                sb.Append("OnSelect = ").Append(bp.OnSelect).AppendLine();

            if (bp.FakeChecks.Length != 0)
                sb.Append("FakeChecks = ").Append(string.Join(", ", bp.FakeChecks.Select(x => x.ToString()))).AppendLine();

            if (sb.Length > 0)
                node.Comment = sb.ToString();

            node.MythicRequirement = ConvertMythicRequirement(bp.MythicRequirement);
            node.AlignmentRequirement = ConvertAlignmentRequirement(bp.AlignmentRequirement);

            NodeDict[node.Guid] = node;
        }

        private void ConvertBlueprintAnswersList(BlueprintAnswersList bp)
        {
            AnswerNode node = new();
            node.Guid = bp.Guid;
            node.Name = bp.Name;

            node.MythicRequirement = ConvertMythicRequirement(bp.MythicRequirement);
            node.AlignmentRequirement = ConvertAlignmentRequirement(bp.AlignmentRequirement);

            node.NextNodes = bp.Answers.ToNodeRefArray();

            NodeDict[node.Guid] = node;
        }

        private void ConvertBlueprintCue(BlueprintCue bp)
        {
            CueNode node = new();

            node.Guid = bp.Guid;
            node.Name = bp.Name;

            node.Speaker = bp.Speaker.GetLocalizedName();

            node.Text = bp.Text;
            node.AlignmentShift = (AlignmentShift)bp.AlignmentShift;

            var nextNodeList = new List<NodeRefBase>();
            nextNodeList.AddRange(bp.Answers.ToNodeRefList());
            nextNodeList.AddRange(bp.Continue.Cues.ToNodeRefList());

            node.NextNodes = nextNodeList.ToArray();

            sb.Clear();

            if (bp.Experience != DialogSystem.DialogExperience.NoExperience)
                sb.Append("Experience = ").Append(bp.Experience).AppendLine();

            if (!bp.OnShow.IsEmpty)
                sb.Append("OnShow = ").Append(bp.OnShow).AppendLine();

            if (!bp.OnStop.IsEmpty)
                sb.Append("OnStop = ").Append(bp.OnStop).AppendLine();

            if (sb.Length > 0)
                node.Comment = sb.ToString();

            NodeDict[node.Guid] = node;
        }

        private void ConvertBlueprintCheck(BlueprintCheck bp)
        {
            CheckNode node = new();
            node.Guid = bp.Guid;
            node.Name = bp.Name;

            node.AlternativeText = $"Check node {bp.Type} DC = {bp.DC}";
            node.Comment = $"Experience = {bp.Experience}\n{bp.GetDCModifierText()}";

            node.NextNodes = new NodeRefBase[] { bp.m_Success.ToNodeRef(), bp.m_Fail.ToNodeRef() };

            NodeDict[node.Guid] = node;
        }

        private void ConvertBlueprintBookPage(BlueprintBookPage bp)
        {
            LinkNode bookPageNode = new();
            bookPageNode.Guid = bp.Guid;
            bookPageNode.Name = bp.Name;
            bookPageNode.Text = bp.Title;

            NodeDict[bookPageNode.Guid] = bookPageNode;
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
        }

        private void ConvertBlueprintSequenceExit(BlueprintSequenceExit bp)
        {
            LinkNode node = new();
            node.Guid = bp.Guid;
            node.Name = bp.Name;

            var nextNodeList = new List<NodeRefBase>();
            nextNodeList.AddRange(bp.Answers.ToNodeRefList());
            nextNodeList.AddRange(bp.Continue.Cues.ToNodeRefList());

            node.NextNodes = nextNodeList.ToArray();

            NodeDict[node.Guid] = node;
        }

        private void ConvertBlueprintCueSequence(BlueprintCueSequence bp)
        {
            LinkNode sequenceStartNode = new();
            sequenceStartNode.Guid = bp.Guid;
            sequenceStartNode.Name = bp.Name;

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

            foreach (var currentNode in currentNodeList)
            {
                currentNode.NextNodes = new NodeRefBase[] { bp.m_Exit.ToNodeRef() };
            }
        }

        private void ConvertBlueprintDialog(BlueprintDialog bp)
        {
            DialogNode node = new();
            node.Guid = bp.Guid;
            node.Name = bp.Name;

            node.NextNodes = bp.FirstCue.Cues.ToNodeRefArray();

            sb.Clear();

            sb.Append($"Dialogue [{bp.Name}]\n");
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

            NodeDict[node.Guid] = node;
            DialogList.Add(node);
        }

        private void ProcessCommandStartDialog(CommandStartDialog bp)
        {
            string speakerName;
            if (!string.IsNullOrEmpty(bp.SpeakerName.Name))
            {
                speakerName = bp.SpeakerName.Name;
            }
            else if (bp.Speaker is not null)
            {
                if (bp.Speaker is CompanionInParty companionInParty)
                {
                    speakerName = companionInParty.m_Companion.Get().LocalizedName.String.Name;
                }
                else if (bp.Speaker is UnitFromSpawner unitFromSpawner)
                {
                    if (EntityUnitDict.TryGetValue(unitFromSpawner.Spawner.UniqueId, out string unitGuid))
                    {
                        unitGuid = EntityUnitDict[unitFromSpawner.Spawner.UniqueId];
                        BlueprintUnit unit = (BlueprintUnit)BlueprintManager.Instance.GetBlueprint(unitGuid);
                        speakerName = unit.LocalizedName.String.Value;
                    }
                    else
                    {
                        speakerName = unitFromSpawner.Spawner.EntityNameInEditor;
                    }
                }
                else if (bp.Speaker is FirstUnitFromSummonPool firstUnitFromSummonPool)
                {
                    speakerName = firstUnitFromSummonPool.m_SummonPool.Name;
                }
                else if (bp.Speaker is DialogCurrentSpeaker)
                {
                    speakerName = null;
                }
                else
                {
                    speakerName = bp.Speaker.ToString();
                }
            }
            else
            {
                return;
            }

            Guid dialogGuid = bp.m_Dialog.Guid;
            if (dialogGuid == Guid.Empty)
                return;

            var dialog = NodeDict[dialogGuid.ToString("N")] as DialogNode;
            dialog.DefaultSpeaker = speakerName;
        }

        private static string ConvertMythicRequirement(Mythic mythicRequirement)
        {
            if (mythicRequirement == Mythic.None)
                return null;
            return mythicRequirement.ToString();
        }

        private static string ConvertAlignmentRequirement(AlignmentComponent alignmentRequirement)
        {
            if (alignmentRequirement == AlignmentComponent.None)
                return null;
            return alignmentRequirement.ToString();
        }
    }
}
