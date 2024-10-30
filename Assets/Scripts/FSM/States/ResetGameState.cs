using UnityEngine;

public class ResetGameState : IGameState
{
    private readonly GameStateMachine _gameStateMachine;
    private Platform _platform;

    public ResetGameState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        _platform = MonoBehaviour.FindAnyObjectByType<Platform>();
    }

    public void Enter()
    {
        _platform.ResetSegments();
        _gameStateMachine.EnterIn<StartGameState>();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}

// ������� �������� � �������� ���������.
// ���� ��� ��������� ��� ���������, �� ������� ��� �� �����.
// ������� ������ �������� ����.
// �������� ����.
// ��������� ������������ ������������.