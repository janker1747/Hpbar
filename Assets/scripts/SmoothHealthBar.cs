using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Image _fillingBar;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.HealthChange += OnHealthChange;
    }

    private void OnHealthChange(float value)
    {
        _fillingBar.fillAmount = value;
    }
}
