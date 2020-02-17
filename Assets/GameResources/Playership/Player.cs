using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthController _playerHealth;
    [SerializeField] private ShipPlayerInput _playerInput;

    public void DisableInput()
    {
        _playerInput.enabled = false;
    }

    public void ResetPlayer()
    {
        _playerHealth.ResetHealth();
        _playerInput.enabled = true;
    }
}
