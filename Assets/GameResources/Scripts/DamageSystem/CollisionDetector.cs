using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var hit = other.gameObject.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.TakeDamage(1);
            Debug.Log($"{hit} is hit");
        }
    }
}
