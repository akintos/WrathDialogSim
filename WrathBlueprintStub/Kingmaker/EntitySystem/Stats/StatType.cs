using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.EntitySystem.Stats
{
    public enum StatType
    {
        Unknown,
        HitPoints = 10,
        TemporaryHitPoints = 22,
        Strength = 1,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma,
        BaseAttackBonus,
        AdditionalAttackBonus,
        AdditionalDamage,
        AttackOfOpportunityCount = 18,
        AC = 11,
        AdditionalCMB,
        AdditionalCMD,
        SaveFortitude,
        SaveWill,
        SaveReflex,
        SkillMobility,
        SkillAthletics = 19,
        SkillPersuasion = 29,
        SkillThievery = 27,
        SkillLoreNature = 35,
        SkillPerception = 20,
        SkillStealth = 42,
        SkillUseMagicDevice,
        SkillLoreReligion = 45,
        SkillKnowledgeWorld = 48,
        SkillKnowledgeArcana = 24,
        CheckBluff = 101,
        CheckDiplomacy,
        CheckIntimidate,
        Initiative = 26,
        Speed = 28,
        SneakAttack = 21,
        Reach = 23,
        DamageNonLethal = 104
    }
}
