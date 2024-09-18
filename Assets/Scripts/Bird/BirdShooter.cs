using UnityEngine;

public class BirdShooter : Spawner<BirdBulletPool, Bullet>
{
    [SerializeField] private InputReader _inputShootKey;

    private void Awake()
    {
        Pool.Initialize();
    }

    private void OnEnable()
    {
        _inputShootKey.ShootKeyPressing += OutputObject;
    }

    private void OnDisable()
    {
        _inputShootKey.ShootKeyPressing -= OutputObject;
    }

    protected override void SetStateObject()
    {
        Bullet bullet = GetObject(SpawnPlace.position);

        bullet.SetDirection(SpawnPlace.right);
    }
}