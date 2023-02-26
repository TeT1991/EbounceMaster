using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private BallJumper _ball;
    [SerializeField] private GameManager _gameManager;

    private BallJumper _currentBall;

    void Start()
    {
        SetBall(_ball);
        SpawnBall();
        _gameManager.GameFinished.AddListener(DestroyBall);
        _gameManager.GameFinished.AddListener(SpawnBall);
    }

    public void SpawnBall()
    {
        _currentBall = Instantiate(_ball, transform);
    }

    public void DestroyBall()
    {
        Destroy(_currentBall.gameObject);
    }

    public void SetBall(BallJumper ball)
    {
        _ball = ball;
    }

    public BallJumper GetCurrentBall()
    {
        return _currentBall;
    }
}
