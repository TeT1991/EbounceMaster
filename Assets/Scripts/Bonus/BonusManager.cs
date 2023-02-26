using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    private bool _isSpawned = false;

    private void Start()
    {


    }

    private void Update()
    {
        if (!_isSpawned)
        {
            _isSpawned = true;  
            StartCoroutine(SpawnBonus());
        }
    }

    private IEnumerator SpawnBonus()
    {
        yield return new WaitForSeconds(7);

        // Create a circle at the center of the screen.
        Vector2 center = new Vector3(0, 0, 0);
        float radius = 2;

        // Select a random point at the edge of the circle.
        float angle = Random.Range(0f, 1f);
        Vector2 pointOnCircle = center + radius * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        // Create a GameObject at that point.
        GameObject obj = Instantiate(_coin, pointOnCircle, Quaternion.identity);
        obj.transform.SetParent(transform, false);
    }

    public void SetSpawnStatus()
    {
        _isSpawned = !_isSpawned;
    }
}
