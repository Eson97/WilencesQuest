using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int CurrentLevel { get; private set; }
    public int CurrentSanityLevel { get; private set; }
    public EventSO CurrentEvent { get; private set; }
    public EventSO LastEventPlayed { get; private set; }
    public LastEventState LastEventResult { get; private set; }
    public GameState State { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        CurrentLevel = 0;
        CurrentSanityLevel = 0;
        LastEventPlayed = null;
        LastEventResult = LastEventState.Undef;
    }

    private void Start() => ChangeState(GameState.Start);

    public static Action<GameState> OnBeforeStateChanged;
    public static Action<GameState> OnAfterStateChanged;

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Start:
                HandleStart();
                break;
            case GameState.Lobby:
                HandleLobby();
                break;
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.Win:
                HandleWin();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            case GameState.Ending:
                HandleEnding();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);

        }

        OnAfterStateChanged?.Invoke(newState);
    }

    private void HandleStart()
    {
    }

    private void HandleEnding()
    {
        if (CurrentSanityLevel < -2) CurrentSanityLevel = -2;
        if (CurrentSanityLevel > 2) CurrentSanityLevel = 2;

        LevelManager.Instance.LoadScene("Ending");
    }

    private void HandleLose()
    {
        CurrentSanityLevel--;
        if (CurrentSanityLevel < -2) CurrentSanityLevel = -2;

        LastEventResult = LastEventState.Lose;

        LevelManager.Instance.LoadScene($"Lobby");
        ChangeState(GameState.Lobby);
    }

    private void HandleWin()
    {
        CurrentSanityLevel++;
        if (CurrentSanityLevel > 2) CurrentSanityLevel = 2;

        LastEventResult = LastEventState.Win;

        LevelManager.Instance.LoadScene($"Lobby");
        ChangeState(GameState.Lobby);
    }

    private void HandleStarting()
    {
        if (CurrentEvent == null) return;
        LastEventPlayed = CurrentEvent;
        LevelManager.Instance.LoadScene($"Level{CurrentLevel}");
    }

    private void HandleLobby()
    {
        CurrentLevel++;
        if (CurrentLevel <= 5)
            CurrentEvent = ResourceSystem.Instance.GetRandomEvent(CurrentLevel);
        else
            CurrentEvent = null;
    }
}

[System.Serializable]
public enum GameState
{
    Start,
    Lobby,
    Starting,
    Win,
    Lose,
    Ending
}

[System.Serializable]
public enum LastEventState
{
    Win,
    Lose,
    Undef
}
