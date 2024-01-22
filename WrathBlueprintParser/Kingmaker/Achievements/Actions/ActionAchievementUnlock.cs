using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Achievements.Actions;
public class ActionAchievementUnlock : GameAction
{
    public override string GetCaption()
    {
        return $"AchievementUnlock({m_Achievement.Name})";
    }

    public BlueprintReferenceBase m_Achievement;
}