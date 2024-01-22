using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;
public class SummonPoolExistsAndEmpty : Condition
{
    protected override string GetConditionCaption()
    {
        return $"SummonPoolExistsAndEmpty({m_SummonPool})";
    }

    public BlueprintReferenceBase m_SummonPool;
}