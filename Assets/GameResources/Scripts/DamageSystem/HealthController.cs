using UnityEngine;

public class HealthController : MonoBehaviour, IDamageable
{
    [SerializeField] private HealthEvent onHealthUpdated;
    [SerializeField] private HealthEvent onDeath;
    [SerializeField] private HealthData healthData;
    private Health _currentHealth;

    private void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        if (_currentHealth == null)
            _currentHealth = new Health();

        _currentHealth.Value = healthData.Health.Value;
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
}
