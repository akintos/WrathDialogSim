using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions;

public class RaiseDead : GameAction
{
    public override string GetCaption()
    {
        if (riseAllCompanions)
        {
            return "RaiseDead(ALL_COMPANIONS)";
        }

        return $"RaiseDead({m_companion})";
    }

    public BlueprintUnitReference m_companion;

    public bool riseAllCompanions;
}