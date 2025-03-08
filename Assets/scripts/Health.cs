using System;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private HealthModifier _damageButton;
    [SerializeField] private HealthModifier _healingButton;

    private float _currentHealth;

    public event Action<float> HealthChange;

    public float GetCurrentHealth() => _currentHealth;
    public float GetMaxHealth() => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        _damageButton.ModifyHealth += TakeDamage;
        _healingButton.ModifyHealth += RecoverHealth;
    }

    private void OnDisable()
    {
        _damageButton.ModifyHealth -= TakeDamage;
        _healingButton.ModifyHealth -= RecoverHealth;
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            return;
        }

        ChangeHealth(damage);
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

        currentHealthAsPercantage = _currentHealth / _maxHealth;
        HealthChange?.Invoke(currentHealthAsPercantage);
    }
}
