using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerShooter))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody;
    private Vector3 _startPosition = Vector3.zero;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0,0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0,0, _minRotationZ);
        Reset();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation,
            _rotationSpeed * Time.deltaTime);
    }

    private void OnMove()
    {
        _rigidbody.velocity = new Vector2(_speed, 0);
        transform.rotation = _maxRotation;
        _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector3.zero;
    }
}