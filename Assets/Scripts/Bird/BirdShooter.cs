using UnityEngine;

public class BirdShooter : Spawner<Pool<Bullet>, Bullet>
{
    [SerializeField] private InputReader _inputShootKey;

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
        Bullet bullet = GetObject();
        Vector2 shootDirection = SpawnPlace.right;

        bullet.SetDirection(shootDirection);
    }
}