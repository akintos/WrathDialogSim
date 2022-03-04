using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators
{
    [Serializable]
    public class IntConstant : IntEvaluator
    {
        public int Value;

        public override string GetCaption()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
