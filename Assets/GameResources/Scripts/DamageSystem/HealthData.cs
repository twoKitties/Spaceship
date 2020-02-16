using UnityEngine;

[CreateAssetMenu(fileName = "NewHealthData", menuName = "Data Objects/HealthData")]
public class HealthData : ScriptableObject
{
    public Health Health => currentValue;
    [SerializeField] private Health currentValue;

    private void OnValidate()
    {
        if (currentValue.Value < 0)
            currentValue.Value = 0;
    }
}
