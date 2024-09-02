using UnityEngine;

public class EnemyBulletSpawner : Spawner<Pool<EnemyBullet>, EnemyBullet>
{
    private void Update()
    {
        AttemptSpawn();
    }

    protected override void PerformSpawn()
    {
        EnemyBullet newBullet = GetObject();
        Vector2 shootDirection = Vector2.left;

        newBullet.SetDirection(shootDirection);
    }
}
