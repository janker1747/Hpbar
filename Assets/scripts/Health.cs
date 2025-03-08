using System;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private float _currentHealth;

    public event Action<float> HealthChange;

    public float GetCurrentHealth() => _currentHealth;
    public float GetMaxHealth() => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            return;
        }

        ChangeHealth(-damage);
    }

    public void RecoverHealth(float amount)
    {
        if (amount < 0)
        {
            return;
        }

        ChangeHealth(amount);
    }

    private void ChangeHealth(float value)
    {
        float currentHealthAsPercantage;

        _currentHealth = Mathf.Clamp(_currentHealth + value, 0, _maxHealth);

        if (0 <= _currentHealth)
        {
            currentHealthAsPercantage = _currentHealth / _maxHealth;
            HealthChange?.Invoke(currentHealthAsPercantage);
        }
    }
}
