using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : HealthBar
{
    [SerializeField] private Image _fillingBar;

    private float _targetFillAmount;
    private Coroutine _smoothCoroutine;

    protected override void OnHealthChanged(float healthPercentage)
    {
        _targetFillAmount = healthPercentage;
        if (_smoothCoroutine != null)
        {
            StopCoroutine(_smoothCoroutine);
        }
        _smoothCoroutine = StartCoroutine(SmoothFill());
    }

    private System.Collections.IEnumerator SmoothFill()
    {
        while (Mathf.Abs(_fillingBar.fillAmount - _targetFillAmount) > 0.01f)
        {
            _fillingBar.fillAmount = Mathf.Lerp(_fillingBar.fillAmount, _targetFillAmount, Time.deltaTime * 5f);
            yield return null;
        }
        _fillingBar.fillAmount = _targetFillAmount;
    }
}