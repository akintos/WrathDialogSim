using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.DialogSystem.Blueprints
{
    public class BlueprintCueBase : SimpleBlueprint
    {
        public bool ShowOnce;
        public bool ShowOnceCurrentDialog;
        public ConditionsChecker Conditions;
    }
}
