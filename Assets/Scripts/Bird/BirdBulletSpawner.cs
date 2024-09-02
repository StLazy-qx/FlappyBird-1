using UnityEngine;

[RequireComponent(typeof(Bird))]

public class BirdBulletSpawner : Spawner<Pool<BirdBullet>, BirdBullet>
{
    [SerializeField] private PauseHandler _pauseHandler;

    private Bird _bird;
    private int _keyShoot = 0;

    private void Start()
    {
        _bird = GetComponent<Bird>();
        _bird.GameOver += Reset;
    }

    private void Update()
    {
        if (_pauseHandler.IsPaused == false)
        {
            AttemptSpawn();
        }
    }

    private void OnDisable()
    {
        _bird.GameOver -= Reset;
    }

    protected override void AttemptSpawn()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > Cooldown)
        {
            if (Input.GetMouseButtonDown(_keyShoot))
            {
                PerformSpawn();

                ElapsedTime = 0;
            }
        }
    }

    protected override void PerformSpawn()
    {
        BirdBullet newBullet = GetObject();
        Vector2 shootDirection = SpawnPlace.right;

        newBullet.SetDirection(shootDirection);
    }
}
