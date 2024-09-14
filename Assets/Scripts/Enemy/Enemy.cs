using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), 
    typeof(EnemyMover))]

public class Enemy : ObjectablePool, IDamageable
{
    [SerializeField] private EnemyShooter _bulletSpawner;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bird bird))
        {
            bird.Destroy();
            Destroy();
        }

        if (collision.TryGetComponent<EnemyDestroyer>(out _))
            Destroy();
    }

    public void Initialize(Vector2 position, EnemyBulletPool bulletPool)
    {
        transform.position = position;
        _bulletSpawner.GetPool(bulletPool);
    }

    public void Destroy()
    {
        Deactivate();
    }
}