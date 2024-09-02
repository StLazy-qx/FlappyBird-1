using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(EnemyMover))]

public class Enemy : ObjectablePool, IDamageable
{
    [SerializeField] private int _touchDamage;
    [SerializeField] private EnemyBulletPool _bulletPool;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            if (bird != null)
            {
                bird.Destroy();
                Disable();
            }
        }

        if (collision.TryGetComponent(out EnemyDestroyer destroyer))
        {
            if (destroyer != null)
                Disable();
        }
    }

    public void ResetBulletPool()
    {
        _bulletPool.Reset();
    }

    public void Destroy()
    {
        Disable();
    }
}
