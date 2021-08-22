using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState instance;
    public static GameState Instance => instance;

    public event Action levelCompleted;
    public event Action loadNextLevel;
    public event Action reloadLevel;

    bool levelComplete = false;

    private void Awake()
    {
        if(!instance)
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
        Door.touchedPlayer += OnDoorTouched;
        PlayerMovement.died += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        reloadLevel?.Invoke();
    }

    private void OnDoorTouched()
    {
        levelComplete = true;

        loadNextLevel?.Invoke();
    }
}
