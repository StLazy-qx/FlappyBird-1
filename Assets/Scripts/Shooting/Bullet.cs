using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public abstract class Bullet : ObjectablePool
{
    [SerializeField] protected float Speed;
    
    protected Vector2 Direction;
    private float _elapsedTime = 0;

    private void Update()
    {
        if (IsActive)
        {
            HandleLifetime();

            transform.Translate(Direction * Speed * Time.deltaTime);
        }
        else
        {
            _elapsedTime = 0;
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.Destroy();
        }

        Disable();
    }

    protected void HandleLifetime()
    {
        float timeLife = 5;
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > timeLife)
        {
            _elapsedTime = 0;

            Disable();
        }
    }

    public virtual void SetDirection(Vector2 direction = default)
    {
        Direction = direction.normalized;
    }
}
