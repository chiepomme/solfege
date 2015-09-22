using System;
using UnityEngine;

public class UserMusicalInput : MonoBehaviour
{
    [SerializeField]
    ClockGenerator ClockGenerator;

    public event Action<Note> Played = delegate { };

    void Start()
    {
        ClockGenerator.Ticked += OnTick;
    }

    void OnTick(Clock clock)
    {
        if (Input.GetKeyDown(KeyCode.Z)) Played(new Note(clock, NoteNumber.C));
        if (Input.GetKeyDown(KeyCode.X)) Played(new Note(clock, NoteNumber.D));
        if (Input.GetKeyDown(KeyCode.C)) Played(new Note(clock, NoteNumber.E));
        if (Input.GetKeyDown(KeyCode.V)) Played(new Note(clock, NoteNumber.F));
    }
}
