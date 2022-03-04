using Kingmaker.EntitySystem.Stats;

namespace Kingmaker.DialogSystem.Blueprints
{
    public class ShowCheck
    {
        public StatType Type;
        public int DC;

        public override string ToString()
        {
            if (Type == StatType.Unknown) return string.Empty;
            return $"Check({Type}, DC: {DC})";
        }
    }
}
