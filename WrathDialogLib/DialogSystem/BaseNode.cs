using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathDialogLib.DialogSystem;

public abstract class BaseNode
{
    public string Guid { get; set; }
    public string? Name { get; set; }

    public LocalizedString? Text { get; set; }
    public virtual string? AlternativeText => null;

    public string? Comment { get; set; }
    public string? Conditions { get; set; }

    public AlignmentShift? AlignmentShift { get; set; }

    public NodeRefBase[] NextNodes = Array.Empty<NodeRefBase>();
    public NodeRef<DialogNode>? Dialog;
    public NodeRefBase? PrevNode;

    protected BaseNode(string guid, string? name)
    {
        Guid = guid;
        Name = name;
    }

    public virtual bool HasNextNode()
    {
        return NextNodes.Length != 0;
    }

    public virtual string GetSpeaker()
    {
        return Name;
    }

    public virtual bool HasText => AlternativeText is not null || (!Text?.IsEmptyString() ?? false);

    public virtual List<BaseNode> GetDisplayableChildNodes()
    {
        List<BaseNode> result = new();
        HashSet<NodeRefBase> visitedNodes = new();
        Queue<NodeRefBase> queue = new();

        Array.ForEach(NextNodes, queue.Enqueue);

        while (queue.Count != 0)
        {
            var nextNodeRef = queue.Dequeue();
            if (visitedNodes.Contains(nextNodeRef))
            {
                continue;
            }
            visitedNodes.Add(nextNodeRef);
            var nextNode = nextNodeRef.Get();
            if (nextNode.HasText)
            {
                result.Add(nextNode);
            }
            else
            {
                foreach (var item in nextNode.NextNodes)
                {
                    if (!visitedNodes.Contains(item))
                    {
                        queue.Enqueue(item);
                    }
                }
            }
        }

        return result;
    }
}
