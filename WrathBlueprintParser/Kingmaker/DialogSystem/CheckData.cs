using Kingmaker.EntitySystem.Stats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.DialogSystem
{
    public class CheckData
    {
        public StatType Type;
        public int DC;

        public override string ToString()
        {
            if (Type == StatType.Unknown) return string.Empty;
            return $"Check({Type}, DC: {DC})";
        }
    }
}
