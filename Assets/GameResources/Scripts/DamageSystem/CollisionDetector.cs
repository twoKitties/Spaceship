using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [SerializeField] private CollisionHandler[] handlers;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var item in handlers)
        {
            item.ExecuteOnCollision(other, gameObject);
        }
    }
}
