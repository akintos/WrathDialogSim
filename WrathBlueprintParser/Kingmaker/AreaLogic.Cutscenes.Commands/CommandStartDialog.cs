using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.Localization;

namespace Kingmaker.AreaLogic.Cutscenes.Commands
{
    public class CommandStartDialog : SimpleBlueprint
    {
        public BlueprintDialogReference m_Dialog;

        public UnitEvaluator Speaker;

        public LocalizedString SpeakerName;

        public BlueprintEvaluator Dialog;
    }
}
