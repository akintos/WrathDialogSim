using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Kingdom.Conditions;
public class KingdomProjectIsDone : Condition
{
    protected override string GetConditionCaption()
    {
        return $"KingdomProjectIsDone({m_Project})";
    }

    public BlueprintReferenceBase m_Project;
}