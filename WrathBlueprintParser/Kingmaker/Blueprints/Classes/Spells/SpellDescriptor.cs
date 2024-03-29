﻿using System;

namespace Kingmaker.Blueprints.Classes.Spells
{
    [Flags]
    public enum SpellDescriptor : long
    {
        None = 0L,
        Fire = 1L,
        Acid = 2L,
        Cold = 4L,
        Electricity = 8L,
        MindAffecting = 16L,
        Fear = 32L,
        Compulsion = 64L,
        Emotion = 128L,
        Poison = 256L,
        Summoning = 512L,
        Good = 1024L,
        Evil = 2048L,
        Chaos = 4096L,
        Law = 8192L,
        Disease = 16384L,
        Charm = 32768L,
        Daze = 65536L,
        Sickened = 131072L,
        Shaken = 262144L,
        Fatigue = 524288L,
        Staggered = 1048576L,
        Nauseated = 2097152L,
        Frightened = 4194304L,
        Exhausted = 8388608L,
        Stun = 16777216L,
        Paralysis = 33554432L,
        Confusion = 67108864L,
        Blindness = 134217728L,
        Curse = 268435456L,
        Death = 536870912L,
        Sonic = 1073741824L,
        Cure = 2147483648L,
        Sleep = 4294967296L,
        Polymorph = 8589934592L,
        Trample = 17179869184L,
        Force = 34359738368L,
        StatDebuff = 68719476736L,
        RestoreHP = 137438953472L,
        TemporaryHP = 274877906944L,
        Bomb = 549755813888L,
        BreathWeapon = 1099511627776L,
        Bleed = 2199023255552L,
        VilderavnBleed = 4398046511104L,
        SightBased = 8796093022208L,
        Ground = 17592186044416L,
        Petrified = 35184372088832L,
        NegativeEmotion = 70368744177664L,
        GazeAttack = 140737488355328L,
        Metal = 281474976710656L,
        MovementImpairing = 562949953421312L,
        Hex = 1125899906842624L,
        FearImmunity = 2251799813685248L,
        UndeadControl = 4503599627370496L,
        ChannelPositiveHeal = 9007199254740992L,
        ChannelNegativeHeal = 18014398509481984L,
        ChannelPositiveHarm = 36028797018963968L,
        ChannelNegativeHarm = 72057594037927936L,
        Arcane = 144115188075855872L,
        Divine = 288230376151711744L,
        Trap = 576460752303423488L,
        Siege = 1152921504606846976L,
        Stratagem = 2305843009213693952L,
        NegativeLevel = 4611686018427387904L,
        AnomalyDistortion = -9223372036854775808L
    }
}
