using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Con Fig Vars
    [SerializeField]
    bool skipFirstLoad = false;
    [Tooltip("In seconds"), SerializeField]
    float levelLoadDelay = 5f;

    // State Vars

    void Awake()
    {
        int numSceneLoaders = FindObjectsOfType<SceneLoader>().Length;

        if (numSceneLoaders > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadFirstSceen());
    }

    public void ReloadOnPlayerDeath(float loadDelay)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadSelectScene(sceneIndex, loadDelay));
    }

    private IEnumerator LoadFirstSceen()
    {
        yield return new WaitForSeconds(levelLoadDelay);
        if (!skipFirstLoad) SceneManager.LoadScene(1);
    }

    private IEnumerator LoadSelectScene(int sceneIndex, float loadDelay)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneIndex);
    }
}
