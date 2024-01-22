using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;

namespace Kingmaker.DialogSystem.Blueprints
{
    public class BlueprintSequenceExit : SimpleBlueprint
    {
        public List<BlueprintAnswerBaseReference> Answers = new List<BlueprintAnswerBaseReference>();

        public CueSelection Continue;
    }
}
