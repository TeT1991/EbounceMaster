using UnityEngine;

public class InitGameState : IGameState
{
    private readonly GameStateMachine _gameStateMachine;

    private Platform _platform;

    public InitGameState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        _platform = MonoBehaviour.FindAnyObjectByType<Platform>();
    }

    public void Enter()
    {
        _platform.Initialize();
        _gameStateMachine.EnterIn<ResetGameState>();
    }

    public void Exit()
    {
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}

//Init platform
