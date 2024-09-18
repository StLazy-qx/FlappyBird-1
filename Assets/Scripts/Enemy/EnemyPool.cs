using UnityEngine;

public class EnemyPool : Pool<Enemy>  
{
    [SerializeField] private EnemyBulletPool _enemyBullet;

    public override void Initialize()
    {
        for (int i = 0; i < Capacity; i++)
        {
            Enemy newEnemy = CreateNewObject();
            newEnemy.InitializeBulletPool(_enemyBullet);
        }
    }
}