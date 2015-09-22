using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScorePlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource BGMSource;
    [SerializeField]
    ClockGenerator ClockGenerator;
    [SerializeField]
    NotePlayer NotePlayer;
    [SerializeField]
    UserMusicalInput MusicalInput;

    Score Score;
    Clock previousClock = new Clock(-1);

    void Awake()
    {
        var tempo = 130f;

        var notes = new List<Note>()
        {
            new Note(new Clock(tempo , 4 * 0 + 0), NoteNumber.C),
            new Note(new Clock(tempo , 4 * 0 + 1), NoteNumber.D),
            new Note(new Clock(tempo , 4 * 0 + 2), NoteNumber.E),
            new Note(new Clock(tempo , 4 * 0 + 3), NoteNumber.E),
            new Note(new Clock(tempo , 4 * 1 + 1), NoteNumber.D),
            new Note(new Clock(tempo , 4 * 1 + 2), NoteNumber.C),
        };

        var copybook = new Copybook(new Clock(tempo, 4 * 0), new Clock(tempo, 4 * 4), notes);
        var userplay = new UserPlay(new Clock(tempo, 4 * 4), copybook);

        var phases = new List<IPlayPhase>()
        {
            copybook,
            userplay,
        };

        Score = new Score(phases);
    }

    void Start()
    {
        MusicalInput.Played += OnPlay;
        ClockGenerator.Ticked += OnTick;
    }

    public void Play()
    {
        BGMSource.Play();
    }

    void OnPlay(Note playedNote)
    {
        var notesToPlay = Score.OfType<UserPlay>()
                               .SelectMany(phase => phase)
                               .Where(note => Mathf.Pow((playedNote.Clock - note.Clock).Seconds, 2) < 0.05 * 0.05);
        if (notesToPlay.Any())
        {
            Debug.Log("GREAT");
        }
        else
        {
            Debug.Log("MISS");
        }

        NotePlayer.Play(playedNote.NoteNumber);
    }

    void OnTick(Clock clock)
    {
        PlayEventsAfterPreviousPlay(clock);
    }

    void PlayEventsAfterPreviousPlay(Clock clock)
    {
        var notesToPlay = Score.OfType<Copybook>()
                               .SelectMany(phase => phase)
                               .Where(note => previousClock < note.Clock)
                               .Where(note => note.Clock <= clock);

        foreach (var note in notesToPlay)
        {
            NotePlayer.Play(note.NoteNumber);
        }

        previousClock = clock;
    }
}
