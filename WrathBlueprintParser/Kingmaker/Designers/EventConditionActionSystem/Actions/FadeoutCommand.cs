using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions;

public class FadeoutCommand : GameAction
{
    public override string GetCaption()
    {
        return $"FadeoutCommand({m_Time} seconds)";
    }

    public float m_Time = 2f;

    public bool m_OverrideAnimTime;

    public float m_AnimTime = 2f;

    public ActionList m_InFadeActions;
}