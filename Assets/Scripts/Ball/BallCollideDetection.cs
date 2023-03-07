using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollideDetection : MonoBehaviour
{
    public UnityEvent PlatformCollisionDetected;

    [SerializeField] private BallJumper _ball;
    [SerializeField] private bool _isFirstBounce = false;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        Initialize();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_gameManager != null)
        {
            if (_gameManager.CheckGameStarted())
            {

                if (_isFirstBounce)
                {
                    if (collision.gameObject.TryGetComponent<Obstacle>(out Obstacle obstacle))
                    {
                        obstacle.CollideAction();
                        Debug.Log("OBSTACLE");
                    }
                }
                else
                {
                    _isFirstBounce = true;
                }
            }
        }
        else
        {
            Initialize();
        }
    }

    public void Initialize()
    {
            _gameManager = FindObjectOfType<GameManager>();
    }

}
