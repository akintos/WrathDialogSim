using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;
public class MaxPartySize : IntEvaluator
{
    public override string GetCaption()
    {
        return "MAX_PARTY_SIZE";
    }
}
