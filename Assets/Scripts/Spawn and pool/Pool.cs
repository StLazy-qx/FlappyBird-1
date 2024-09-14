using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Pool<T> : MonoBehaviour where T : ObjectablePool
{
    [SerializeField] private T _template;
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;
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

    public void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            T newObj = Instantiate(_template, _container);

            newObj.Deactivate();
            _pool.Add(newObj);
        }
    }

    public T GetObject(Vector2 position)
    {
        T newObj = _pool.FirstOrDefault(îbj => îbj.IsActive == false);

        if (newObj == null)
        {
            newObj = Instantiate(_template, _container);

            newObj.Deactivate();
            _pool.Add(newObj);
        }

        newObj.transform.position = position;

        newObj.Activate();

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
