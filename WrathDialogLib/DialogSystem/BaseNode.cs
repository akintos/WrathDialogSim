using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathDialogLib.DialogSystem
{
    public abstract class BaseNode
    {
        public string Guid;
        public string? Name;

        public LocalizedString? Text;
        public string? AlternativeText;

        public string? Comment;

        public AlignmentShift? AlignmentShift;

        public NodeRefBase[] NextNodes = Array.Empty<NodeRefBase>();
        public NodeRef<DialogNode>? Dialog;
        public NodeRefBase? PrevNode;

        public virtual bool HasNextNode()
        {
            return NextNodes.Length != 0;
        }

        public virtual string GetSpeaker()
        {
            return Name ?? "UNKNOWN";
        }
    }
}
