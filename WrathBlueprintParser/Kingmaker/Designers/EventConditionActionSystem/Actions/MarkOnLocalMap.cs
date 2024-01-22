using Kingmaker.EntitySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions;

public class MarkOnLocalMap : GameAction
{
    public override string GetCaption()
    {
        return string.Format("MarkOnLocalMap({0}, {1})", MapObject, Hidden ? "HIDDEN" : "MARKED");
    }

    public MapObjectEvaluator MapObject;

    public bool Hidden;
}