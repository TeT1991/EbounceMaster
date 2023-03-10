using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Obstacle
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _bonusScores;

    private WaitForSeconds _waitForSeconds;
    private BonusManager _bonusManager;


    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_lifeTime);    
        _bonusManager = FindObjectOfType<BonusManager>();
        StartCoroutine(LifetimeOver());
    }

    public override void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }

    public override void CollideAction()
    {
        ScoresManager scoresManager = FindObjectOfType<ScoresManager>();
        scoresManager.AddScores(_bonusScores);
        Destroy(gameObject);
    }

    private IEnumerator LifetimeOver()
    {
        yield return _waitForSeconds;
        _bonusManager.SetSpawnStatus();
        Destroy(gameObject);
    }
}
