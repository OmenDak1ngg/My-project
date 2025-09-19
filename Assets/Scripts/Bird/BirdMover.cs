using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    [SerializeField] private float _gravityScale;

    private Vector3 _startPosition;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;


    private Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _inputReader.Jumped += Jump;
    }

    private void OnDisable()
    {
        _inputReader.Jumped -= Jump;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;

        _maxRotation = Quaternion.Euler(0,0,_maxRotationZ);
        _minRotation = Quaternion.Euler(0,0,_minRotationZ);

        _rigidbody.gravityScale = _gravityScale;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_speed, _tapForce);
        transform.rotation = _maxRotation;
    }
}
