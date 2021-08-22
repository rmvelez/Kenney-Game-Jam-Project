using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private static SceneLoader instance;
    public static SceneLoader Instance => instance;

    public Scene TitleScene
    {
        get { return SceneManager.GetSceneByName("TitleScene"); }
    }

    public Scene WinScene
    {
        get { return SceneManager.GetSceneByName("WinScene"); }
    }

    public Scene Level(int number)
    {
        return SceneManager.GetSceneByName($"Level{number}");
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            SubscribeEvents();
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void SubscribeEvents()
    {
        GameState.Instance.loadNextLevel += LoadNextLevel;
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(Level(1).buildIndex, LoadSceneMode.Single);
    }
}
