using System;
using UnityEngine;

public class ClockGenerator : MonoBehaviour
{
    public event Action<Clock> Ticked = delegate { };

    [SerializeField]
    AudioSource BGMSource;

    void Update()
    {
        Ticked(new Clock(BGMSource.time));
    }
}
