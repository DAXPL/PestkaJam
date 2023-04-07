using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayMinigame : MonoBehaviour
{
    [SerializeField] private UnityEvent minigameStartEvent;
    [SerializeField] private UnityEvent minigameEndEvent;
    bool active = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active && collision.CompareTag("Player"))
        {
            LevelManager.Instace.LockPlayer(true);
            minigameStartEvent.Invoke();
        }
    }

    public void OnGameWin()
    {
        LevelManager.Instace.LockPlayer(false);
        active = false;
        minigameEndEvent.Invoke();
    }
}
