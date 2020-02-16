using UnityEngine;

[CreateAssetMenu(fileName = "NewPoolData", menuName = "Data Objects/PoolData")]
public class PoolData : ScriptableObject
{
    public string PoolName => poolName;
    public PooledObject Prefab => prefab;
    public int StartCount => startCount;
    [SerializeField] private string poolName;
    [SerializeField] private PooledObject prefab;
    [SerializeField] private int startCount;
}
