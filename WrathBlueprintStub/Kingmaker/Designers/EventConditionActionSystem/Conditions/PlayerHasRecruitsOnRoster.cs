using System;
using System.Linq;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class PlayerHasRecruitsOnRoster : Condition
    {
        protected override string GetConditionCaption()
        {
            return "PlayerHasRecruitsOnRoster";
        }
    }
}
