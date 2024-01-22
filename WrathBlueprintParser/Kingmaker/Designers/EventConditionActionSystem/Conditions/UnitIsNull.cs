using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;

public class UnitIsNull : Condition
{
    protected override string GetConditionCaption()
    {
        return $"UnitIsNull({Target})";
    }

    public UnitEvaluator Target;
}