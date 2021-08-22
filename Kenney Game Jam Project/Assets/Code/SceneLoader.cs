using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;
    public static SceneLoader Instance => instance;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        SubscribeEvents();
    }

    void SubscribeEvents()
    {
        GameState.Instance.loadNextLevel += LoadNextLevel;
        GameState.Instance.reloadLevel += ReloadLevel;
    }

    void LoadNextLevel()
    {
        int current = SceneManager.GetActiveScene().buildIndex;

        if (current + 1 > (int)Scene.LastLevel)
        {
            SceneManager.LoadScene((int)Scene.TitleScene);
            return;
        }

        SceneManager.LoadScene( current + 1 );
    }

    void ReloadLevel()
    {
        var current = SceneManager.GetSceneAt(0);
        SceneManager.LoadSceneAsync(current.buildIndex);
    }
}

public enum Scene
{
    TitleScene = 0,
    TestScene = 1,
    FirstLevel = 2,
    LastLevel = 5,
    WinScene = 6,
}
