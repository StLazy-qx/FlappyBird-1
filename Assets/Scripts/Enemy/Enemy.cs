using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(EnemyMover))]

public class Enemy : ObjectablePool, IDamageable
{
    [SerializeField] private EnemyShooter _bulletSpawner;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            if (bird != null)
            {
                bird.Destroy();
                Destroy();
            }
        }

        if (collision.TryGetComponent(out EnemyDestroyer destroyer))
        {
            if (destroyer != null)
                Destroy();
        }
    }

    public void ResetState()
    {
        _bulletSpawner.Reset();
    }

    public void Destroy()
    {
        Deactivate();
    }
}
