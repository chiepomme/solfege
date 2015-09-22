using System.Collections.Generic;

public interface IPlayPhase : IEnumerable<Note>
{
    Clock StartsAt { get; }
    Clock FinishesAt { get; }
}