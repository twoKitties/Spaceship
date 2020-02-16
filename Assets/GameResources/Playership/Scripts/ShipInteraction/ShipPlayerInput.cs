using UnityEngine;

[RequireComponent(typeof(ShipMover))]
public class ShipPlayerInput : MonoBehaviour
{
    private ShipMover _shipMover;
    private Cannon _shipCannon;

    private void Awake()
    {
        _shipMover = GetComponent<ShipMover>();
        _shipCannon = GetComponent<Cannon>();
    }

    private void Update()
    {
        _shipMover.Move(GetPlayerInput());
        _shipCannon.Shoot(Input.GetButtonDown("Jump"));
    }

    private Vector3 GetPlayerInput()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
    }
}
