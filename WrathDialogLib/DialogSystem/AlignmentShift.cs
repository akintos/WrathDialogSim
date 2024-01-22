namespace WrathDialogLib.DialogSystem;

public class AlignmentShift
{
    public AlignmentShiftDirection Direction = AlignmentShiftDirection.TrueNeutral;

    public int Value;

    public LocalizedString? Description;

    public override string ToString() => $"{Direction}({Value}, {Description})";
}

public enum AlignmentShiftDirection
{
    LawfulGood,
    NeutralGood,
    ChaoticGood,
    LawfulNeutral,
    TrueNeutral,
    ChaoticNeutral,
    LawfulEvil,
    NeutralEvil,
    ChaoticEvil,
    Good,
    Evil,
    Lawful,
    Chaotic
}
