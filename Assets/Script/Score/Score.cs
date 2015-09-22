using System.Collections;
using System.Collections.Generic;

public class Score : IEnumerable<IPlayPhase>
{
    readonly List<IPlayPhase> Phases = new List<IPlayPhase>();

    public Score(IEnumerable<IPlayPhase> phases)
    {
        Phases.AddRange(phases);
    }

    public IEnumerator<IPlayPhase> GetEnumerator()
    {
        return Phases.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Phases.GetEnumerator();
    }
}
