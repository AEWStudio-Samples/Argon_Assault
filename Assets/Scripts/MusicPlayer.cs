using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    // Con Fig Vars
    [SerializeField] float levelLoadDelay = 5f;

    // State Vars

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadFirstSceen", levelLoadDelay);
    }

    // Update is called once per frame
    void LoadFirstSceen()
    {
        SceneManager.LoadScene(1);
    }
}
