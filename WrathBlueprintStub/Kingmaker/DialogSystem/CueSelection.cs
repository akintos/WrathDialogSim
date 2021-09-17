using System.Collections.Generic;

using Kingmaker.Blueprints;

namespace Kingmaker.DialogSystem
{
    public class CueSelection
    {
        public List<BlueprintCueBaseReference> Cues = new List<BlueprintCueBaseReference>();

        public Strategy Strategy;
    }
}
