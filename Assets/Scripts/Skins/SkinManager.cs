using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private List<BallJumper> _skins;

    [SerializeField] private SkinCellHolder _skinCellHolderPrefab;
    [SerializeField] private Transform _contentSkinCells;
    [SerializeField] private int _skinCount;
    [SerializeField] private BallSpawner _ballSpawner;

    private List<SkinCellHolder> _skinCellHolders = new List<SkinCellHolder>();

    private void Start()
    {
        _ballSpawner.SetBall(_skins[1]);

        for (int i = 0; i < _skinCount; i++)
        {
            var skinCellHolder = Instantiate(_skinCellHolderPrefab, _contentSkinCells);
            skinCellHolder.Initialization(i);
            _skinCellHolders.Add(skinCellHolder);
        }
    }

    public BallJumper GetSkin(int value)
    {
        return _skins[value];
    }

    public void SpawnBallWithNewSkin()
    {
        _ballSpawner.DestroyBall();
    }

    public void SetCurrentSkin(BallJumper skin)
    {
        _ballSpawner.SetBall(skin);
        _ballSpawner.DestroyBall();
        _ballSpawner.SpawnBall();

            BallJumper currentBall = _ballSpawner.GetCurrentBall();
    currentBall.GetComponent<BallCollideDetection>().Initialize();
    }




}
