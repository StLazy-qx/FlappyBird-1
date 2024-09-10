using UnityEngine;

public class EnemySpawner : Spawner<Pool<Enemy>, Enemy>
{
    [SerializeField] private float _maxCoordinateSpawnY;
    [SerializeField] private float _minCoordinateSpawnY;
    [SerializeField] private Bird _bird;

    private void FixedUpdate()
    {
        InitializeObject();
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

        newEnemy.transform.position = DetermineSpawnCoordinate();
    }

    private Vector2 DetermineSpawnCoordinate()
    {
        return new Vector2(SpawnPlace.position.x,
            Random.Range(_minCoordinateSpawnY, _maxCoordinateSpawnY));
    }
}
