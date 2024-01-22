using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions;

public class UnitDismount : GameAction
{
    public override string GetCaption()
    {
        return $"UnitDismount{Unit})";
    }

    public UnitEvaluator Unit;
}
