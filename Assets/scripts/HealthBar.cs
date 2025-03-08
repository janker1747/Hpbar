using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMaxHealth;
    [SerializeField] private TMP_Text _textCurrentHealth;
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.HealthChange += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChange += OnHealthChanged;   
    }

    private void OnHealthChanged(float healthPercentage)
    {
        _slider.value = healthPercentage;
        UpdateHealthText(_health.GetCurrentHealth(), _health.GetMaxHealth());
    }

    private void UpdateHealthText(float currentHealth, float maxHealth)
    {
        if (_textMaxHealth != null)
            _textMaxHealth.text = maxHealth.ToString();

        if (_textCurrentHealth != null)
            _textCurrentHealth.text = currentHealth.ToString();
    }
}
