using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlatformRotator : MonoBehaviour
{
    [SerializeField] private float _rotationPower;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _constantRotationSpeed;

    private float _direction;

    private Rigidbody _rigidbody;

    private void Start()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        _rigidbody.centerOfMass = Vector3.zero;
        _rigidbody.maxAngularVelocity = _maxSpeed;
    }

    private void Update()
    {
        Rotate();
        TryStopTorque();
    }

    private void Rotate()
    {
        SetDirection();

        _rigidbody.AddTorque(Vector3.up * CalculateRotationSpeed(), ForceMode.VelocityChange);
    }

    private void SetDirection()
    {
        _direction = 0;

        if (Input.GetKey(KeyCode.A))
        {
            _direction = 1;

        }
        if (Input.GetKey(KeyCode.D))
        {
            _direction = -1;
        }
    }

    private float CalculateRotationSpeed()
    {
        return _rotationPower * Time.deltaTime * _direction;
    }

    private void TryStopTorque()
    {
        if(_direction == 0)
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}