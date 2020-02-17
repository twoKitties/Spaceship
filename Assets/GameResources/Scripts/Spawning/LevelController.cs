using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private PoolData asteroidsData;
    [SerializeField] private CameraInfo cam;
    [SerializeField] private SpawnZone spawnZone;
    private LevelData _levelData;
    private bool _isActive;
    private Coroutine _spawnRoutine;

    public void StartSpawn(LevelData levelData)
    {
        _levelData = levelData;
        _isActive = true;
        ClearAllSpawnees();
        _spawnRoutine = StartCoroutine(SpawnWave());
    }

    public void StopSpawn()
    {
        _isActive = false;
        if (_spawnRoutine != null)
            StopCoroutine(_spawnRoutine);

        ClearAllSpawnees();
    }

    public void PauseSpawn()
    {
        _isActive = !_isActive;
    }

    private void ClearAllSpawnees()
    {
        foreach (var item in PoolManager.Instance.GetAllObjects(asteroidsData))
        {
            item.Push();
        }
    }

    private IEnumerator SpawnWave()
    {
        var wait = new WaitForSecondsRealtime(_levelData.WaveDelay);
        while (_isActive)
        {
            Vector2[] spawnPoints = CreateSpawnPoints(_levelData.AsteroidsPerWave);
            foreach (var spot in spawnPoints)
            {
                var asteroid = PoolManager.Instance.GetObject(asteroidsData);
                asteroid.transform.position = spot;
                asteroid.SetActive(true);
            }
            yield return wait;
        }
    }

    private Vector2[] CreateSpawnPoints(int amount)
    {
        Vector2[] points = new Vector2[amount];
        for (int i = 0; i < amount; i++)
        {
            points[i] = spawnZone.SpawnPoint;
        }
        return points;
    }
}
