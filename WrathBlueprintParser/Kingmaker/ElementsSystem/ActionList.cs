using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.ElementsSystem
{
    public class ActionList
    {
        public override string ToString()
        {
            if (Actions.Length == 0)
            {
                return string.Empty;
            }
            else if (Actions.Length == 1)
            {
                return Actions[0]?.ToString() + ";";
            }

            return string.Join("; ", Actions.Select(x => x?.ToString())) + ";";
        }

        public string LambdaFormat()
        {
            if (IsEmpty)
                return "null";

            return $"() => {{ {this.ToString()} }}";
        }

        public GameAction[] Actions = Array.Empty<GameAction>();

        public bool IsEmpty => Actions.Length == 0;
    }
}
