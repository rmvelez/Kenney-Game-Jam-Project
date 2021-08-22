using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour
{
    public enum GameState {TitleState, LearnState, CreditState};
    public GameState currentGameState;

    public GameObject title;
    public GameObject learn;
    public GameObject credit;

    // Start is called before the first frame update
    void Start()
    {
        currentGameState = GameState.TitleState;
        ShowScreen(title);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGane()
    {
        SceneManager.LoadScene("Level1");
    }

    public void HowToPlay()
    {
        currentGameState = GameState.LearnState;
        ShowScreen(learn);
    }

    public void ShowCredits()
    {
        currentGameState = GameState.CreditState;
        ShowScreen(credit);
    }

    public void BackToStart()
    {
        currentGameState = GameState.TitleState;
        ShowScreen(title);
    }

    private void ShowScreen(GameObject gameObjectToShow)
    {
        title.SetActive(false);
        learn.SetActive(false);
        credit.SetActive(false);

        gameObjectToShow.SetActive(true);
    }
}
