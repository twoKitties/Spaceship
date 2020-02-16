using UnityEngine;
using System.Collections.Generic;

public class Pool
{
    public string Name { get; private set; }
    private List<PooledObject> _objects;
    private PooledObject _prefab;
    private int _startCount;

    public Pool(PoolData data)
    {
        _objects = new List<PooledObject>();
        Name = data.PoolName;
        _prefab = data.Prefab;
        _startCount = data.StartCount;

        for (int i = 0; i < data.StartCount; i++)
        {
            AddObject();
        }
    }

    private void AddObject()
    {
        var pooledObject = Object.Instantiate(_prefab);
        pooledObject.ReturnToPool();
        _objects.Add(pooledObject);
    }

    public PooledObject GetObject()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (!_objects[i].gameObject.activeInHierarchy)
            {
                return _objects[i];
            }
        }

        AddObject();
        return _objects[_objects.Count - 1];
    }
}
