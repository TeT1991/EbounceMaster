using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresManager : MonoBehaviour
{
    [SerializeField] private BallCollideDetection _ballCollideDetection;
    private int _scoresCount = 0;

    private void Start()
    {
        _ballCollideDetection.PlatformCollisionDetected.AddListener(AddScore);
    }

    private void AddScore()
    {
        _scoresCount++;
    }
}
