using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    protected Health Health;

    protected virtual void Awake()
    {
        Health = GetComponent<Health>();

        if (Health == null)
        {
            return;
        }

        Health.HealthChange += OnHealthChanged;
    }

    protected virtual void OnDestroy()
    {
        if (Health != null)
        {
            Health.HealthChange -= OnHealthChanged;
        }
    }

    protected abstract void OnHealthChanged(float healthPercentage);
}