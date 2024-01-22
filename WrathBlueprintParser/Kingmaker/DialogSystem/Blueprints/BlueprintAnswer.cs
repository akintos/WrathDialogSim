using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.DialogSystem.Blueprints
{
    public class BlueprintAnswer : BlueprintAnswerBase
    {

        public LocalizedString Text;

        public CueSelection NextCue;

        public bool ShowOnce;
        public bool ShowOnceCurrentDialog;

        public ShowCheck ShowCheck;

        public DialogExperience Experience;

        public bool DebugMode;

        public CharacterSelection CharacterSelection;

        public ConditionsChecker ShowConditions;
        public ConditionsChecker SelectConditions;

        public bool RequireValidCue;

        public bool AddToHistory = true;

        public ActionList OnSelect;

        public CheckData[] FakeChecks;

        public AlignmentShift AlignmentShift = new AlignmentShift();
    }
}
