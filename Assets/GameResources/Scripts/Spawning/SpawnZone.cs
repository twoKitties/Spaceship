using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public Vector2 SpawnPoint => transform.TransformPoint(Random.insideUnitCircle);
    [SerializeField] private Color32 gizmoColor = Color.white;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
