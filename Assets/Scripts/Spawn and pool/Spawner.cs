using UnityEngine;

public abstract class Spawner<T,N> : MonoBehaviour where T : Pool <N> where N : ObjectablePool
{
    [SerializeField] protected T Pool;
    [SerializeField] protected Transform SpawnPlace;
    [SerializeField] protected float Cooldown;

    protected float ElapsedTime = 0;

    private void Update()
    {
        ElapsedTime += Time.deltaTime;
    }

    protected abstract void SetStateObject();

    protected void OutputObject()
    {
        if (ElapsedTime > Cooldown)
        {
            SetStateObject();

            ElapsedTime = 0;
        }
    }

    protected N GetObject(Vector2 position)
    {
        return Pool.GetObject(position);
    }

    public void Reset()
    {
        Pool.Reset();
    }
}