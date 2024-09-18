using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private InputReader _inputKeyMove;
    [SerializeField] private PauseHandler _pauseHandler;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForca;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxPosition;

    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation,
            _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _inputKeyMove.FlyKeyPressing += Fly;
        _bird.Reseting += Reset;
    }

    private void OnDisable()
    {
        _inputKeyMove.FlyKeyPressing -= Fly;
        _bird.Reseting += Reset;
    }

    private void Fly()
    {
        if (transform.position.y < _maxPosition)
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForca);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation,
            _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Reset()
    {
        _rigidbody.velocity = Vector2.zero;
    }
}