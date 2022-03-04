using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class DealDamage : GameAction
    {
        public override string GetCaption()
        {
            if (NoSource) return $"DealDamage({Target})";
            return $"DealDamage({Source}, {Target})";
        }

        public bool NoSource;

        public UnitEvaluator Source;

        public UnitEvaluator Target;

        // public DamageDescription Damage;

        public bool DisableBattleLog;

        public bool DisableFxAndSound;
    }
}
