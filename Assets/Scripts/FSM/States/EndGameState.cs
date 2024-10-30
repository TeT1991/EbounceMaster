using UnityEngine;

public class EndGameState : IGameState
{
    private readonly GameStateMachine _gameStateMachine;

    public EndGameState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        Debug.Log("ENDGAME");
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}

// "”ничтожить" шарик.
