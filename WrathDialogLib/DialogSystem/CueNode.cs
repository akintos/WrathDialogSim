using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathDialogLib.DialogSystem
{
    public class CueNode : BaseNode
    {
        public string? Speaker;

        public override string GetSpeaker()
        {
            return Speaker ?? "UNKNWON_SPEAKER";
        }
    }
}
