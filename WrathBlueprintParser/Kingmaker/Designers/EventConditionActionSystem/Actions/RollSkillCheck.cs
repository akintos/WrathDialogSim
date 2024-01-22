using Kingmaker.EntitySystem.Stats;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions;
public class RollSkillCheck : GameAction
{
    public override string GetCaption()
    {
        return $"RollSkillCheck({Stat}, {Unit}, DC: {DC})";
    }

    public StatType Stat;

    public UnitEvaluator Unit;

    public int DC;

    public bool LogSuccess = true;

    public bool LogFailure;

    public bool Voice = true;

    /// <summary>
    /// In capital and camp all rolls are made by party (by default). Set to true to prevent it")]
    /// </summary>
    public bool ForbidPartyHelpInCamp;

    public ActionList OnSuccess;

    public ActionList OnFailure;
}
