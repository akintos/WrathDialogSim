using System;
using System.Collections.Generic;

using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.DialogSystem.Blueprints
{
    public class BlueprintAnswersList : BlueprintAnswerBase
    {
        public bool ShowOnce;

        public ConditionsChecker Conditions = new ConditionsChecker();

        public List<BlueprintAnswerBaseReference> Answers = new List<BlueprintAnswerBaseReference>();
    }
}
