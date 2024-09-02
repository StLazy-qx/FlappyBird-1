using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Pool<T> : MonoBehaviour where T : ObjectablePool
{
    [SerializeField] private T _template;
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<T> _pool = new List<T>();

    public void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            T newObj = Instantiate(_template, _container);

            newObj.Disable();
            _pool.Add(newObj);
        }
    }

    public virtual T GetObject()
    {
        T newObj = _pool.FirstOrDefault(îbj => îbj.IsActive == false);

        if (newObj == null)
        {
            newObj = Instantiate(_template, _container);

            newObj.Disable();
            _pool.Add(newObj);
        }

        return newObj;
    }

    public List<T> GetObjectsList()
    {
        return _pool;
    }

    public void Reset()
    {
        foreach (T obj in _pool)
        {
            obj.Disable();
        }
    }
}
