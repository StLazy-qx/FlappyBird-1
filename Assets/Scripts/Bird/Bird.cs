using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]

public class Bird : MonoBehaviour, IDamageable
{
    private BirdMover _mover;
    private bool _isLive;

    public event UnityAction GameOver;

    public bool IsLive => _isLive;

    private void Awake()
    {
        _isLive = true;
        _mover = GetComponent<BirdMover>();
    }

    public void Reset()
    {
        _isLive = true;

        _mover.Reset();
    }

    public void Destroy()
    {
        if (_isLive == true)
        {
            _isLive = false;

            GameOver?.Invoke();
        }
    }
}
