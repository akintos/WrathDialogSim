using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrathDialogLib.DialogSystem
{
    public class DialogNode : BaseNode
    {
        public string? DefaultSpeaker;

        public DialogType Type;
    }

    public enum DialogType
    {
        Common,
        Book,
        Interchapter,
        Epilogue,
    }
}
