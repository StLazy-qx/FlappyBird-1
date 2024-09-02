using UnityEngine;
using UnityEngine.Events; 

public abstract class Spawner<T,N> : MonoBehaviour where T : Pool <N> where N : ObjectablePool
{
    [SerializeField] protected T Pool;
    [SerializeField] protected Transform SpawnPlace;
    [SerializeField] protected float Cooldown;

    protected float ElapsedTime = 0;

    private void Start()
    {
        Pool.Initialize();
    }

    protected abstract void PerformSpawn();

    protected virtual void AttemptSpawn()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > Cooldown)
        {
            ElapsedTime = 0;

            PerformSpawn();
        }
    }

    protected virtual N GetObject()
    {
        N newObject = Pool.GetObject();
        Vector2 direction = SpawnPlace.position;

        ActivateObject(newObject, direction);
        return newObject;
    }

    protected void ActivateObject(N obj, Vector2 position)
    {
        obj.transform.position = position;

        obj.Enable();
    }

    protected virtual void Reset()
    {
        Pool.Reset();
    }
}
