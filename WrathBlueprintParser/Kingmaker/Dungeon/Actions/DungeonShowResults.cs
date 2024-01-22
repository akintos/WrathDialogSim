namespace Kingmaker.Dungeon.Actions;

public class DungeonShowResults : GameAction
{
    public override string GetCaption()
    {
        return $"DungeonShowResults({Result})";
    }

    public ResultType Result;

    public enum ResultType
    {
        LOOSE,
        WIN,
        END_TIER
    }
}