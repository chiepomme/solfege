using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField]
    ScorePlayer ScorePlayer;

    void Start()
    {
        ScorePlayer.Play();
    }
}
