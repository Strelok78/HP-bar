using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HP_bar : MonoBehaviour
{
    [SerializeField] private HeroCharacteristics _heroCaracteristics;
    [SerializeField] private float _barSmoothinessRate;

    private Slider _healthIndicatorSlider;
    private Coroutine _barChanging;

    private void Awake()
    {
        _healthIndicatorSlider = GetComponent<Slider>();
        _healthIndicatorSlider.maxValue = _heroCaracteristics.MaxHealth;
        _healthIndicatorSlider.wholeNumbers = false;
        _healthIndicatorSlider.value = _healthIndicatorSlider.maxValue;
    }

    private void OnEnable()
    {
        _heroCaracteristics.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _heroCaracteristics.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        if (_barChanging != null)
            StopCoroutine(_barChanging);

        _barChanging = StartCoroutine(BarSmoothing(health));
    }

    IEnumerator BarSmoothing(float health)
    {
        float smoothiness = Time.deltaTime * _barSmoothinessRate;

        while (_healthIndicatorSlider.value != health)
        {
            _healthIndicatorSlider.value = Mathf.MoveTowards(_healthIndicatorSlider.value, health, smoothiness);
            yield return null;
        }
    }
}
