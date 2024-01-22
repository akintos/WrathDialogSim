using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
    public class CameraToPosition : GameAction
    {
        public override string GetCaption()
        {
            return string.Format("Camera To Position ({0})", this.Position);
        }

        public PositionEvaluator Position;
    }
}
