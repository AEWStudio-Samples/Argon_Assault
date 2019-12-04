using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Con Fig Vars

    // State Vars

    void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPlayers > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
