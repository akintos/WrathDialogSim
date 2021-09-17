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
            return string.Join(", ", Actions.Select(x => x.ToString()));
        }

        public GameAction[] Actions = new GameAction[0];
    }
}
