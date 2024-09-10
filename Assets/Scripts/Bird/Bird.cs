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

    public void Reset()
    {
        transform.position = _beginPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        IsLive = true;

        Reseting?.Invoke();
    }

    public void Destroy()
    {
        IsLive = false;
        
        GameOvered?.Invoke();
    }
}
