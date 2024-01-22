namespace Kingmaker.UnitLogic.Alignments;

public class AlignmentShift
{
    public AlignmentShiftDirection Direction = AlignmentShiftDirection.TrueNeutral;

    public int Value;

    public LocalizedString Description;

    public override string ToString() => $"{Direction}({Value}, {Description})";

    public static implicit operator WrathDialogLib.DialogSystem.AlignmentShift(AlignmentShift obj)
    {
        if (obj.Direction == AlignmentShiftDirection.TrueNeutral) return null;

        return new WrathDialogLib.DialogSystem.AlignmentShift()
        {
            Direction = (WrathDialogLib.DialogSystem.AlignmentShiftDirection)obj.Direction,
            Value = obj.Value,
            Description = obj.Description
        };
    }
}
