using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileKinematicMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + Vector3.up * speed * Time.deltaTime);
    }
}
