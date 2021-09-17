
using Kingmaker.Localization;

namespace Kingmaker.UnitLogic.Alignments
{
    public class AlignmentShift
    {
        public AlignmentShiftDirection Direction = AlignmentShiftDirection.TrueNeutral;

        public int Value;

        public LocalizedString Description;

        public override string ToString() => $"{Direction}({Value}, {Description})";
    }
}
