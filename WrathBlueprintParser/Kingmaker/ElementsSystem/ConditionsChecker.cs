using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.ElementsSystem
{
    [Serializable]
    public class ConditionsChecker
    {
        public override string ToString()
        {
            return string.Join(Operation == Operation.Or ? " || " : " && ", Conditions.Select(x => x?.ToString()));
        }

        public Operation Operation;

        public Condition[] Conditions;

        public bool IsEmpty => Conditions.Length == 0;
    }
}
