using UnityEngine;
using System.Collections;

public class StartGameState : IGameState
{
    private readonly GameStateMachine _gameStateMachine;
    private Platform _platform;

    public StartGameState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        _platform = MonoBehaviour.FindAnyObjectByType<Platform>();
    }

    public void Enter()
    {
        _gameStateMachine.EnterIn<InProgressGameState>();
    }

    public void Exit()
    {
    }

    public void Update()
    {
        
    }
}

// Поменять статус нескольких сегментов
// Включить Отслеживание столкновений.
// 
