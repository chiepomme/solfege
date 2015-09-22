using System.Collections.Generic;
using UnityEngine;

public class NotePlayer : MonoBehaviour
{
    [SerializeField]
    List<AudioSource> KeySounds;

    public void Play(NoteNumber noteNumber)
    {
        KeySounds[noteNumber.Number].Play();
    }
}
