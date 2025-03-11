using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool IsGamePaused {get; private set;}
    public int Score {get; private set;}

    protected override void Awake()
    {
        base.Awake();
        InitializeGame();
    }

    private void InitializeGame()
    {
        IsGamePaused = false;
        Score = 0;
    }

    public void AddScore(int amount)
    {
        Score += amount;
    }
}
