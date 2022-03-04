using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class TimeSkip : GameAction
    {

        public override string GetCaption()
        {
            if (m_Type == SkipType.Minutes)
            {
                return $"TimeSkip({MinutesToSkip}min, nofatigue: {NoFatigue})";
            }
            return $"TimeSkip({TimeOfDay}, nofatigue: {NoFatigue})";
        }

        public SkipType m_Type;

        public IntEvaluator MinutesToSkip;

        public string TimeOfDay;

        public bool NoFatigue;

        public enum SkipType
        {
            Minutes,
            TimeOfDay
        }
    }
}
