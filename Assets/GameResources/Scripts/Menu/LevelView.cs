using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private GameObject blocker;
    [SerializeField] private LevelDataSetter levelSetter;

    private void OnEnable()
    {
        blocker.SetActive(IsClosed(levelSetter.LevelData));
    }

    private bool IsClosed(LevelData levelData)
    {
        if (levelData.State == LevelState.Open)
            return false;
        else
            return true;
    }
}
