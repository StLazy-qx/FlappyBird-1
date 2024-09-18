using System;
using UnityEngine;

[RequireComponent(typeof(BirdMover))]

public class Bird : MonoBehaviour, IDamageable
{
    private Vector3 _beginPosition;

    public event Action GameOvered;
    public event Action Reseting;

    public bool IsLive { get; private set; }

    private void Start()
    {
        _beginPosition = transform.position;
        IsLive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<GroundZone>(out _))
            Destroy();
    }

    public void Reset()
    {
        transform.position = _beginPosition;
        transform.rotation = Quaternion.identity;
        IsLive = true;

        Reseting?.Invoke();
    }

    public void Destroy()
    {
        IsLive = false;
        
        GameOvered?.Invoke();
    }
}