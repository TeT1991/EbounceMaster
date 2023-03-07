using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Obstacle
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private List<Segment> _segments;
    [SerializeField] private ScoresManager _scoresManager;    

    private void Start()
    {
        _gameManager.GameFinished.AddListener(ResetSegmentsStatus);
    }

    public override void CollideAction()
    {
        if(_ball == null)
        {
            LoadBall();
        }

        Ray ray = new Ray(_ball.transform.position, Vector3.down);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.isTrigger && hits[i].collider.TryGetComponent<Segment>(out Segment segment))
            {

                if (!segment.IsDangerous)
                {
                    List<int> indexes = new List<int>();

                    for (int j = 0; j < _segments.Count/2; j++) //Добавить зависимость от сложности
                    {
                        int index = GetRandomIndex(indexes);
                        _segments[index].ChangStatus();
                        indexes.Add(index);
                    }

                    if (!segment.IsDangerous)
                    {
                        segment.ChangStatus();
                        _scoresManager.AddScores(1);
                    }
                }
                else
                {
                    _gameManager.GameFinished.Invoke();
                }
            }
        }
    }

    private int GetRandomIndex(List<int> indexes)
    {
        int randomIndex = Random.Range(0, _segments.Count);

        while (indexes.Contains(randomIndex))
        {
            randomIndex = Random.Range(0, _segments.Count);
        }
        return randomIndex; 
    }

    private void ResetSegmentsStatus()
    {
        for (int i = 0; i < _segments.Count; i++)
        {
            _segments[i].ResetStatus();
        }
    }
}
