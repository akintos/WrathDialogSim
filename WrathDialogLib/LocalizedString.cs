namespace WrathDialogLib;

public sealed record class LocalizedString
{
    public string Guid { get; set; }
    public string Value { get; set; }

    private static readonly string GUID_EMPTY = System.Guid.Empty.ToString();

    public LocalizedString(string guid, string value)
    {
        Guid = guid;
        Value = value;
    }

    public override string ToString()
    {
        return Value;
    }

    public bool IsEmptyString() => Guid is null || Guid == GUID_EMPTY;
}
