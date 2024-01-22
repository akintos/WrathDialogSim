using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class CompleteEtude : GameAction
    {
        public override string GetCaption()
        {
            return string.Format("CompleteEtude({0})", Etude);
        }

        public BlueprintReferenceBase Etude;
    }
}
