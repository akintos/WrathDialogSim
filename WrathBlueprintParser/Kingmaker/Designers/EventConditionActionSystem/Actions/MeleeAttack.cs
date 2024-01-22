using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions;
public class MeleeAttack : GameAction
{
    public override string GetCaption()
    {
        return $"MeleeAttack(Caster: {Caster}, Target: {Target}, AutoHit: {AutoHit}, IgnoreStatBonus: {IgnoreStatBonus})";
    }

    public UnitEvaluator Caster;

    public UnitEvaluator Target;

    public bool AutoHit;

    public bool IgnoreStatBonus;
}