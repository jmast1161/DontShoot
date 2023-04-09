using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventsBehavior : MonoBehaviour
{
    public static GameEventsBehavior Current { get; private set; }

    public bool GameOverShown { get; private set;}

    private void Awake() 
    {
        Current = this;   
    }    
    
    public event Action OnEnemyDestroyed;
    public event Action OnGameOver;

    public void EnemyDestroyed()
    {
        if (OnEnemyDestroyed != null)
        {
            OnEnemyDestroyed();
        }
    }

    public void GameOver()
    {
        if (OnGameOver != null)
        {
            GameOverShown = true;
            OnGameOver();
        }
    }
}
