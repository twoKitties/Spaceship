using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataController : MonoBehaviour
{
    public static LevelDataController Instance { get; private set; }
    public LevelData CurrentData;
    private List<LevelData> _levels = new List<LevelData>();

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private int GetNextIndex(LevelData current)
    {
        int currentIndex = _levels.FindIndex(item => item == current);
        currentIndex++;
        return currentIndex;
    }

    public int GetCurrentIndex()
    {
        return _levels.FindIndex(item => item == CurrentData);
    }

    public LevelData GetNextLevel()
    {
        return _levels[GetNextIndex(CurrentData)];
    }
}
