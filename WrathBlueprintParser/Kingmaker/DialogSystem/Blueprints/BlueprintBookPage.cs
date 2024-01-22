using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.DialogSystem.Blueprints
{
    public class BlueprintBookPage : BlueprintCueBase
    {
        public List<BlueprintCueBaseReference> Cues = new List<BlueprintCueBaseReference>();

        public List<BlueprintAnswerBaseReference> Answers = new List<BlueprintAnswerBaseReference>();

        public ActionList OnShow;

        // public SpriteLink ImageLink;
        // public SpriteLink ForeImageLink;

        public LocalizedString Title;
    }
}
