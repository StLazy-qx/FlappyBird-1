using UnityEngine;

public class EnemySpawner : Spawner<Pool<Enemy>, Enemy>
{
    [SerializeField] private float _maxCoordinateSpawnY;
    [SerializeField] private float _minCoordinateSpawnY;
    [SerializeField] private Bird _bird;

    private void Update()
    {
        AttemptSpawn();
    }

    private void OnEnable()
    {
        _bird.GameOver += Reset;
    }

    private void OnDisable()
    {
        _bird.GameOver -= Reset;
    }

    protected override void PerformSpawn()
    {
        Enemy newEnemy = GetObject();
        Vector2 spawnPosition = DetermineSpawnCoordinate();

        ActivateObject(newEnemy, spawnPosition);
    }

    protected override Enemy GetObject()
    {
        Enemy newEnemy = Pool.GetObject();

        newEnemy.ResetBulletPool();
        return newEnemy;
    }

    private Vector2 DetermineSpawnCoordinate()
    {
        float randomPositionY = Random.Range(_minCoordinateSpawnY, _maxCoordinateSpawnY);
        Vector2 randomPosition = new Vector2(SpawnPlace.position.x, randomPositionY);

        return randomPosition;
    }

    protected override void Reset()
    {
        base.Reset();

        foreach (Enemy enemy in Pool.GetObjectsList())
        {
            enemy.ResetBulletPool();
        }
    }
}
