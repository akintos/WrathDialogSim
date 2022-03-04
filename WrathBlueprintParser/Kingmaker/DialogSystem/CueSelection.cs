using System.Collections.Generic;

using Kingmaker.Blueprints;

namespace Kingmaker.DialogSystem
{
    public class CueSelection
    {
        public List<BlueprintCueBaseReference> Cues = new();

        public Strategy Strategy;
    }
}
