using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.ElementsSystem
{
    [Serializable]
    public abstract class Condition : Element
    {
        public override string GetCaption()
        {
            return Not ? "!" + GetConditionCaption() : GetConditionCaption();
        }

        protected abstract string GetConditionCaption();

        public bool Not = false;
    }
}
