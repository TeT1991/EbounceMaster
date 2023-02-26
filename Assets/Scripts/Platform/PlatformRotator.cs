using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _constantRotationSpeed;
    [SerializeField] private GameManager _gameManager;

    private Rigidbody _rigidbody;
    private bool _isGameStarted = false;

    private void Start()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>(); 
        }
        _gameManager.GameStarted.AddListener(StopConstantRotation);
        _gameManager.GameFinished.AddListener(StartConstantRotation);
        _rigidbody.centerOfMass = Vector3.zero;

    }

    private void FixedUpdate()
    {
        _rigidbody.centerOfMass = Vector3.zero;

        if (!_isGameStarted)
        {
            _rigidbody.AddTorque(Vector3.up * _constantRotationSpeed * Time.deltaTime, ForceMode.Impulse);
        }
        else 
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody.AddTorque(Vector3.up * _rotationSpeed * Time.deltaTime, ForceMode.Impulse);
            }            
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody.AddTorque(Vector3.up * _rotationSpeed * Time.deltaTime * -1, ForceMode.Impulse);
            }
        }
    }

    private void StopConstantRotation()
    {
        _isGameStarted = true;
        _rigidbody.velocity = Vector3.zero * _rotationSpeed;
    }

    private void StartConstantRotation()
    {
        _isGameStarted = false;
    }
}
