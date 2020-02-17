using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public static event Action<int> onDeath;
    [SerializeField] private int pointsPerKill = 100;

    private void OnTriggerEnter(Collider other)
    {
        var target = other.GetComponent<MissleHolder>();
        if (target != null)
            onDeath?.Invoke(pointsPerKill);
    }
}
