using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;
public class RandomPartyUnit : UnitEvaluator
{
    public override string GetCaption()
    {
        return $"RandomPartyUnit(ExceptPlayerCharacter: {ExceptPlayerCharacter})";
    }

    public bool ExceptPlayerCharacter;

    public ConditionsChecker Conditions;

    public UnitEvaluator UnitIfNoVariants;

    public BlueprintUnitReference[] m_ForbiddenBlueprints;
}