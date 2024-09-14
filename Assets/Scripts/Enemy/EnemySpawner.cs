using UnityEngine;

public class EnemySpawner : Spawner<Pool<Enemy>, Enemy>
{
    [SerializeField] private EnemyBulletPool _enemyBullet;
    [SerializeField] private float _maxCoordinateSpawnY;
    [SerializeField] private float _minCoordinateSpawnY;
    [SerializeField] private Bird _bird;

    private void FixedUpdate()
    {
        OutputObject();
    }

    private void OnEnable()
    {
        _bird.Reseting += Reset;
    }

    private void OnDisable()
    {
        _bird.Reseting -= Reset;
    }

    protected override void SetStateObject()
    {
        Enemy newEnemy = GetObject();

        newEnemy.Initialize(DetermineSpawnCoordinate(), _enemyBullet);
    }

    private Vector2 DetermineSpawnCoordinate()
    {
        return new Vector2(SpawnPlace.position.x,
            Random.Range(_minCoordinateSpawnY, _maxCoordinateSpawnY));
    }
}
