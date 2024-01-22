using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;

namespace Kingmaker.DialogSystem.Blueprints
{
    public class BlueprintCueSequence : BlueprintCueBase
    {
        public List<BlueprintCueBaseReference> Cues = new List<BlueprintCueBaseReference>();

        public BlueprintSequenceExitReference m_Exit;
    }
}
