using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipMover : MonoBehaviour
{
    [SerializeField] private CameraInfo _camera;
    [SerializeField] private float speed = 10;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 input)
    {
        var desiredPosition = GetDesiredPosition(input);
        desiredPosition = _camera.ClampPositionInsideCameraFOV(desiredPosition);
        _rigidbody.MovePosition(desiredPosition);
    }

    private Vector3 GetDesiredPosition(Vector3 input) => _rigidbody.position + input * speed * Time.deltaTime;
}
