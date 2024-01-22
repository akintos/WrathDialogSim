using Kingmaker.EntitySystem.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.DialogSystem
{
    [Serializable]
    public class CharacterSelection
    {
        public Type SelectionType;

        public StatType[] ComparisonStats;

        [Serializable]
        public enum Type
        {
            Clear,
            Keep,
            Random,
            Player,
            Manual,
            Companion,
            Capital
        }
    }
}
