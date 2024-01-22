using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions;
public class ShiftAlignment : GameAction
{
    public override string GetCaption()
    {
        string unit = Unit?.GetCaption() ?? "--";
        string amount = Amount?.GetCaption() ?? "--";
        return string.Format("ShiftAlignment({0}, {1}, {2})", unit, this.Alignment, amount);
    }

    public UnitEvaluator Unit;

    public AlignmentShiftDirection Alignment;

    public IntEvaluator Amount;
}

public enum AlignmentShiftDirection
{
    LawfulGood,
    NeutralGood,
    ChaoticGood,
    LawfulNeutral,
    TrueNeutral,
    ChaoticNeutral,
    LawfulEvil,
    NeutralEvil,
    ChaoticEvil,
    Good,
    Evil,
    Lawful,
    Chaotic
}