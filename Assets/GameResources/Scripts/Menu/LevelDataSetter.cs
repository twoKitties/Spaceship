using UnityEngine;

public class LevelDataSetter : MonoBehaviour
{
    public LevelData LevelData => levelData;
    [SerializeField] private LevelData levelData;

    public void SetLevelData()
    {
        LevelDataController.Instance.CurrentData = levelData;
    }
}
