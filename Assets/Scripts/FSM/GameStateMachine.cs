using System;
using System.Collections.Generic;

public class GameStateMachine 
{
    private Dictionary<Type, IGameState> _states;
    private IGameState _currentState;

    public GameStateMachine()
    {
        _states = new Dictionary<Type, IGameState>()
        {
            [typeof(InitGameState)] = new InitGameState(this),
            [typeof(ResetGameState)] = new ResetGameState(this),
            [typeof(StartGameState)] = new StartGameState(this),
            [typeof(InProgressGameState)] = new InProgressGameState(this),
            [typeof(EndGameState)] = new EndGameState(this)
        };
    }

    public void EnterIn<TState>() where TState : IGameState
    {
        if(_states.TryGetValue(typeof(TState), out IGameState state))
        {
            _currentState?.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}
