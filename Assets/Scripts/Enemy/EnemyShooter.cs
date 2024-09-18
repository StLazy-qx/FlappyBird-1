using UnityEngine;

public class EnemyShooter : Spawner<EnemyBulletPool, Bullet>
{
    private void FixedUpdate()
    {
        OutputObject();
    }
    
    protected override void SetStateObject()
    {
        Bullet newBullet = GetObject(SpawnPlace.position);
        Vector2 shootDirection = Vector2.left;

        newBullet.SetDirection(shootDirection);
    }

    public void SetPoolBullets(EnemyBulletPool bulletPool)
    {
        Pool = bulletPool;

        Pool.Initialize();
    }
}