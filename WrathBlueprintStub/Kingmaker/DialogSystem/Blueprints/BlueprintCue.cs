using System.Collections.Generic;

using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.Alignments;

namespace Kingmaker.DialogSystem.Blueprints
{
    public class BlueprintCue : BlueprintCueBase
    {
        public LocalizedString Text;

        public DialogExperience Experience;
        public DialogAnimation Animation;

        public DialogSpeaker Speaker;
        public bool TurnSpeaker = true;

        public BlueprintUnitReference m_Listener;

        public ActionList OnShow;
        public ActionList OnStop;

        public AlignmentShift AlignmentShift = new AlignmentShift();

        public List<BlueprintAnswerBaseReference> Answers = new List<BlueprintAnswerBaseReference>();

        public CueSelection Continue;
    }
}
