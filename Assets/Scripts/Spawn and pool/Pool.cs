using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Pool<T> : MonoBehaviour where T : ObjectablePool
{
    [SerializeField] protected T Template; 
    [SerializeField] protected Transform Container;
    [SerializeField] protected int Capacity;
    [SerializeField] private Bird _bird;

    private List<T> _pool = new List<T>();

    private void OnEnable()
    {
        _bird.GameOvered += Reset;
        _bird.Reseting += Reset;
    }

    private void OnDisable()
    {
        _bird.GameOvered -= Reset;
        _bird.Reseting -= Reset;
    }

    protected T CreateNewObject()
    {
        T newObj = Instantiate(Template, Container);

        newObj.Deactivate();
        _pool.Add(newObj);

        return newObj;
    }

    public virtual void Initialize()
    {
        for (int i = 0; i < Capacity; i++)
            CreateNewObject();
    }

    public T GetObject(Vector2 position)
    {
        T newObj = _pool.FirstOrDefault(obj => !obj.IsActive) ?? CreateNewObject();

        newObj.Activate();
        newObj.transform.position = position;

        return newObj;
    }

    public void Reset()
    {
        foreach (T obj in _pool)
        {
            obj.Deactivate();
        }
    }
}
