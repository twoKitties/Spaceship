using UnityEngine;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    [SerializeField] private PoolData[] availablePools;
    private List<Pool> _pools = new List<Pool>();

    private void Awake()
    {
        if (Instance)
            Destroy(gameObject);
        else
            Instance = this;

        foreach (var pool in availablePools)
        {
            var newPool = new Pool(pool);
            _pools.Add(newPool);
            Debug.Log($"{pool.PoolName} created");
        }
    }

    private Pool GetPool(PoolData data) => _pools.Find(item => item.Name == data.PoolName);

    public GameObject GetObject(PoolData data) => GetPool(data).GetObject().gameObject;
}
