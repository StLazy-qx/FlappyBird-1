using System.Collections;
using UnityEngine;
using UnityEngine.Events; 

public abstract class Spawner<T,N> : MonoBehaviour where T : Pool <N> where N : ObjectablePool
{
    [SerializeField] protected T Pool;
    [SerializeField] protected Transform SpawnPlace;
    [SerializeField] protected float Cooldown;

    protected float ElapsedTime;

    private void Start()
    {
        Pool.Initialize();
    }

    protected abstract void SetStateObject();

    protected virtual void InitializeObject()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > Cooldown)
        {
            SetStateObject();

            ElapsedTime = 0;
        }
    }

    protected virtual N GetObject()
    {
        Vector2 position = SpawnPlace.position;
        N newObject = Pool.GetObject(position);

        return newObject;
    }

    public virtual void Reset()
    {
        Pool.Reset();
    }
}
