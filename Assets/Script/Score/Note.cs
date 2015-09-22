public struct Note
{
    public readonly Clock Clock;
    public readonly NoteNumber NoteNumber;

    public Note(Clock clock, NoteNumber noteNumber)
    {
        Clock = clock;
        NoteNumber = noteNumber;
    }
}
