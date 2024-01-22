using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    [Serializable]
    public class FlagValue : IntEvaluator
    {
        public BlueprintReferenceBase m_Flag;

        public override string GetCaption()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return m_Flag.Name;
        }
    }
}
