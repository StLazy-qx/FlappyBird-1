using UnityEngine;

public class BirdBullet : Bullet
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}
