using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class UserPlay : IPlayPhase
{
    readonly Copybook Copybook;
    public Clock StartsAt { get; private set; }
    public Clock FinishesAt { get; private set; }

    readonly List<Note> Notes;

    public UserPlay(Clock startsAt, Copybook copybook)
    {
        StartsAt = startsAt;
        FinishesAt = startsAt + (copybook.FinishesAt - copybook.StartsAt);
        Copybook = copybook;
        Notes = copybook.Select(note => MoveCopybookNotesBasedOnLocalClock(note)).ToList();
    }

    Note MoveCopybookNotesBasedOnLocalClock(Note note)
    {
        var localClock = note.Clock - Copybook.StartsAt;
        var transformedClock = localClock + StartsAt;
        return new Note(transformedClock, note.NoteNumber);
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
