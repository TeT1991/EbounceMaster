using UnityEngine;

public class InProgressGameState : IGameState
{
    private readonly GameStateMachine _gameStateMachine;
    private Platform _platform;

    public InProgressGameState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
        _platform = MonoBehaviour.FindAnyObjectByType<Platform>();
    }

    public void Enter()
    {
        Debug.Log("InProgress");
        _platform.SetDangerSegments(5);//ѕолучить данные из вне
        _platform.SegmentActivated += SelectAction;
    }

    public void Exit()
    {
        _platform.SegmentActivated -= SelectAction;
    }

    public void Update()
    {
        _platform.SetDangerSegments(5);
        
        Debug.Log("UPDATE");
    }

    private void SelectAction(Segment segment)
    {
        switch (segment.Type)
        {
            case SegmentTypes.Safe:
                Debug.Log("SAFE");
                Update();
                _platform.SetSegmentType(segment, SegmentTypes.Danger);
                break;

            case SegmentTypes.Danger:
                _gameStateMachine.EnterIn<EndGameState>();
                break;

        }
    }
}
// —делать опасные сегменты
//ѕолучить данные о столкновении: если безопасно, то начислить очки, если опасно, перейти в EndGame, если бонус - начислить бонус.
// ќбновить отображение очков.
