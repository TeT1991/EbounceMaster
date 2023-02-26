using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _safeMaterial;
    [SerializeField] private Material _dangerousMaterial;
    [SerializeField] public bool IsDangerous { get; private set; }

    private void Start()
    {
        IsDangerous = false;
        SetColor();
    }

    public void ChangStatus()
    {
        IsDangerous = !IsDangerous;
        SetColor();
    }

    public void ResetStatus()
    {
        IsDangerous = false;
        SetColor();
    }

    public void SetColor() 
    {
        if (!IsDangerous)
        {
            _meshRenderer.material = _safeMaterial;
        }
        else
        {
            _meshRenderer.material = _dangerousMaterial;
        }
    }
}