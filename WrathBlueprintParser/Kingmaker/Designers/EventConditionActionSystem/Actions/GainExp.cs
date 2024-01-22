using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class GainExp : GameAction
    {
        public override string GetCaption()
        {
            return $"GainExp(CR: {CR}, Modifier: {Modifier}, Encounter: {Encounter})";
        }

        public string Encounter;

        public int CR;

        public float Modifier = 1f;

        public IntEvaluator Count;

        public bool Dummy;
    }
}
