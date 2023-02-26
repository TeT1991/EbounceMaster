using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonMono<GameManager>
{
    [SerializeField] private BallJumper _ball;
    [SerializeField] private BallCollideDetection _ballCollideDetection;
    [SerializeField] private Menu _menu;

    public UnityEvent GameStarted;
    public UnityEvent GameFinished; 
    private bool _isGameStarted = false;


    private void Start()
    {
        GameStarted.AddListener(StartGame);
        GameFinished.AddListener(FinishGame);
    }

    private void OnMouseDown()
    {
        GameStarted.Invoke();
    }

    public bool CheckGameStarted()
    {
        return _isGameStarted;
    }

    public void FinishGame()
    {
        _isGameStarted = false;
    }
    private void StartGame()
    {
        _isGameStarted = true;
    }
}
