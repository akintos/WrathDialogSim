using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.DialogSystem
{
    public class DialogSpeaker
    {
        public BlueprintUnitReference m_Blueprint;

        public override string ToString() => m_Blueprint.Name;
    }
}
