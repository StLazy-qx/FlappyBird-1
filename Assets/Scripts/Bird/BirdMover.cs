using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private PauseHandler _pauseHandler;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForca;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxPosition;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private KeyCode _flyKey = KeyCode.Space;
    private bool _isFly = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void Update()
    {
        if (_pauseHandler.IsPaused == false)
        {
            if (Input.GetKeyDown(_flyKey))
            {
                _isFly = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isFly)
        {
            if (transform.position.y < _maxPosition)
            {
                _rigidbody.velocity = new Vector2(_speed, _tapForca);
                transform.rotation = _maxRotation;
                _isFly = false;
            }
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        _pauseHandler.ContinueGame();

        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }
}
