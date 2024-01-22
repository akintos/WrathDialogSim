using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;
public class CompanionIsDead : Condition
{
    protected override string GetConditionCaption()
    {
        if (anyCompanion)
        {
            return "CompanionIsDead(ANY_COMPANION)";
        }

        return $"CompanionIsDead({m_companion})";
    }

    public BlueprintUnitReference m_companion;

    public bool anyCompanion;
}