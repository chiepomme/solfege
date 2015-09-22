public struct NoteNumber
{
    public static readonly NoteNumber C = new NoteNumber(0);
    public static readonly NoteNumber Cs = new NoteNumber(1);
    public static readonly NoteNumber D = new NoteNumber(2);
    public static readonly NoteNumber Ds = new NoteNumber(3);
    public static readonly NoteNumber E = new NoteNumber(4);
    public static readonly NoteNumber F = new NoteNumber(5);

    public readonly int Number;

    public NoteNumber(int number)
    {
        Number = number;
    }

    public override int GetHashCode()
    {
        return Number;
    }
}