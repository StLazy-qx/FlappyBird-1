using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), 
    typeof(EnemyMover))]

public class Enemy : ObjectablePool, IDamageable
{
    [SerializeField] private EnemyShooter _bulletSpawner;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
            bird.Destroy();

        if (collision.TryGetComponent<EnemyDestroyer>(out _))
            Destroy();
    }

    public void InitializeBulletPool(EnemyBulletPool bulletPool)
    {
        _bulletSpawner.SetPoolBullets(bulletPool);
    }

    public void Destroy()
    {
        Deactivate();
    }
}