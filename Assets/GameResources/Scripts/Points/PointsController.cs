using System;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public int CurrentPoints => _currentPoints;
    public event Action<int> onPointsUpdated;
    private int _currentPoints;

    private void Awake()
    {
        Asteroid.onDeath += UpdatePoints;
    }

    private void OnDestroy()
    {
        Asteroid.onDeath -= UpdatePoints;
    }

    private void UpdatePoints(int points)
    {
        _currentPoints += points;
        onPointsUpdated?.Invoke(_currentPoints);
    }

    public void ResetPoints()
    {
        _currentPoints = 0;
        onPointsUpdated(_currentPoints);
    }
}
