using System;
using Kingmaker.Kingdom.Blueprints;

namespace Kingmaker.Kingdom.Actions
{
    public class AddMorale : KingdomAction
    {
        public override string GetCaption()
        {
            return $"AddMorale({(Substract ? -Bonus : Bonus)})";
        }

        public bool Substract;
        public int Bonus;
    }
}
