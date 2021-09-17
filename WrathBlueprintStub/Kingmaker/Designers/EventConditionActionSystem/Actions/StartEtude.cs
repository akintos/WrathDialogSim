using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class StartEtude : GameAction
    {
        public override string GetCaption()
        {
            return $"StartEtude({Etude})";
        }

        public BlueprintReferenceBase Etude;
    }
}
