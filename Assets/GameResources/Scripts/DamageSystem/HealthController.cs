using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private HealthEvent onHealthUpdated;
    [SerializeField] private HealthEvent onDeath;
    [SerializeField] private HealthData healthData;
    private Health _currentHealth;

    private void Awake()
    {
        _currentHealth = new Health();
        _currentHealth.Value = healthData.Health.Value;
    }

    private void Start()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        onHealthUpdated?.Raise(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth.Value -= damage;
        UpdateHealth();
        if (_currentHealth.Value <= 0)
            onDeath?.Raise(_currentHealth);
    }
    // Так, у нас на астероиде и на корабле висят HealthControllers, и астероид и корабль должны иметь CollisionDetector, который будет получать компонент
    // IDamageable при ударе и вызывать 
}
