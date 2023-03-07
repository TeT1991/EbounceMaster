using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoresManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoresText;
    private int _scoresCount = 0;

    public void AddScores(int value)
    {
        Debug.Log("Add");
        _scoresCount += value;
        _scoresText.SetText("Scores: " + _scoresCount.ToString());
    }

    public void ResetScores()
    {
        _scoresCount = 0;
        _scoresText.SetText("");
    }
}
