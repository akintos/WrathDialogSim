using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions;
public class SetDeviceTrigger : GameAction
{
    public override string GetCaption()
    {
        return string.Format("SetDeviceTrigger({0}:{1})", this.Device, this.Trigger);
    }

    public MapObjectEvaluator Device;

    public string Trigger;
}