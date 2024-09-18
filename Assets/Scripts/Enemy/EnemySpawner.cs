using UnityEngine;

public class EnemySpawner : Spawner<EnemyPool, Enemy>
{
    [SerializeField] private float _maxCoordinateSpawnY;
    [SerializeField] private float _minCoordinateSpawnY;
    [SerializeField] private Bird _bird;

    private void Awake()
    {
        Pool.Initialize();
    }

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
        Vector2 currentPosition = DetermineSpawnCoordinate();

        GetObject(currentPosition);
    }

    private Vector2 DetermineSpawnCoordinate()
    {
        return new Vector2(SpawnPlace.position.x,
            Random.Range(_minCoordinateSpawnY, _maxCoordinateSpawnY));
    }
}
