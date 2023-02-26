using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private BallCollideDetection _collideDetection;
    [SerializeField] private ParticleSystem _platformCollideEffect;
    private Transform _effectPosition;
    private Rigidbody _rigidbody;
    private bool _isOnAir = true;
    private ParticleSystem _effect;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        if (!_isOnAir)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse) ;
            _isOnAir = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_effect==null)
        {
            _effectPosition = transform;
            _effect = Instantiate(_platformCollideEffect);
            _effect.transform.position = _effectPosition.position;
            _effect.gameObject.transform.parent = null;
        }

        _effect.Play();
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            _isOnAir = false;
        }
    }

}
