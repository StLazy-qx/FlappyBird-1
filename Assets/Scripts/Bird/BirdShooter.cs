using UnityEngine;

public class BirdShooter : Spawner<Pool<Bullet>, Bullet>
{
    [SerializeField] private InputReader _inputShootKey;

    private void OnEnable()
    {
        _inputShootKey.ShootKeyPressing += SetStateObject;
    }

    private void OnDisable()
    {
        _inputShootKey.ShootKeyPressing -= SetStateObject;
    }

    protected override void InitializeObject()
    {
        if (ElapsedTime > Cooldown)
        {
            SetStateObject();

            ElapsedTime = 0;
        }
    }

    protected override void SetStateObject()
    {
        Bullet bullet = GetObject();
        Vector2 shootDirection = SpawnPlace.right;

        bullet.SetDirection(shootDirection);
    }
}
