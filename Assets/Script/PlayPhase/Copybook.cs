using System.Collections;
using System.Collections.Generic;

public class Copybook : IPlayPhase
{
    public Clock StartsAt { get; private set; }
    public Clock FinishesAt { get; private set; }

    readonly List<Note> Notes = new List<Note>();

    public Copybook(Clock startsAt, Clock finishesAt, IEnumerable<Note> notes)
    {
        StartsAt = startsAt;
        FinishesAt = finishesAt;

        Notes.AddRange(notes);
    }

    public IEnumerator<Note> GetEnumerator()
    {
        return Notes.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Notes.GetEnumerator();
    }
}
