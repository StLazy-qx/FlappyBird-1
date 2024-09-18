using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Bullet : ObjectablePool
{
    [SerializeField] protected float Speed;
    [SerializeField] protected float Lifetime;
    [SerializeField] private LayerMask targetLayerMask;

    protected Vector2 Direction;
    private Coroutine _lifeTimeCoroutine;
    private WaitForSeconds _waitLifetime;

    private void Awake()
    {
        _waitLifetime = new WaitForSeconds(Lifetime);
    }

    private void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        _lifeTimeCoroutine = StartCoroutine(MonitorLifetime());
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & targetLayerMask) != 0)
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.Destroy();
                Deactivate();
            }
        }
    }

    private IEnumerator MonitorLifetime()
    {
        yield return _waitLifetime;

        Deactivate();
    }

    public virtual void SetDirection(Vector2 direction = default)
    {
        Direction = direction.normalized;
    }
}