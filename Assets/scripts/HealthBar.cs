using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    protected Health _health;

    protected virtual void Awake()
    {
        _health = GetComponent<Health>();

        if (_health == null)
        {
            return;
        }

        _health.HealthChange += OnHealthChanged;
    }

    protected virtual void OnDestroy()
    {
        if (_health != null)
        {
            _health.HealthChange -= OnHealthChanged;
        }
    }

    protected abstract void OnHealthChanged(float healthPercentage);
}