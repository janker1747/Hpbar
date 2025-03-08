using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TMP_Text _textMaxHealth;
    [SerializeField] private TMP_Text _textCurrentHealth;

    protected override void OnHealthChanged(float healthPercentage)
    {
        _textCurrentHealth.text = Health.GetCurrentHealth().ToString();
        _textMaxHealth.text = Health.GetMaxHealth().ToString();
    }
}