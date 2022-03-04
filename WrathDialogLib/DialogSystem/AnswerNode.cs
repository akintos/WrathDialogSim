using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathDialogLib.DialogSystem
{
    public class AnswerNode : BaseNode
    {
        public string? MythicRequirement;
        public string? AlignmentRequirement;

        public override string GetSpeaker()
        {
            return "Player";
        }
    }
}
