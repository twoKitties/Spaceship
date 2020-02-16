using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileKinematicMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _currentTime;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 2f;
    [SerializeField] private PooledObject pooledObject;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= lifeTime)
        {
            _currentTime = 0;
            pooledObject?.ReturnToPool();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + Vector3.up * speed * Time.deltaTime);
    }
}
