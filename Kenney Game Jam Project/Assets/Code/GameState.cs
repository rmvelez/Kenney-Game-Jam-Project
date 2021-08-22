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

    bool levelComplete = false;

    private void Awake()
    {
        if(!instance)
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
        Door.touchedPlayer += OnDoorTouched;
    }

    private void OnDoorTouched()
    {
        levelComplete = true;
        Debug.Log("Player has reached the door");
    }

}
