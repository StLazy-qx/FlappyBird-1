using UnityEngine;

public class EnemyShooter : Spawner<Pool<Bullet>, Bullet>
{
    private void FixedUpdate()
    {
        InitializeObject();
    }

    protected override void SetStateObject()
    {
        Bullet newBullet = GetObject();
        Vector2 shootDirection = Vector2.left;

        newBullet.SetDirection(shootDirection);
    }
}
