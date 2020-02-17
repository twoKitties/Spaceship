using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Data Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public LevelState State { get; set; }
    public int AsteroidsPerWave => asteroidsPerWave;
    public int PointsToPass => pointsToPass;
    public float WaveDelay => waveDelay;

    [SerializeField] private LevelState state;
    [SerializeField] private int asteroidsPerWave;
    [SerializeField] private int pointsToPass;
    [SerializeField] private float waveDelay;
}

public enum LevelState
{
    Blocked,
    Open,
}
