using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HP_bar : MonoBehaviour
{
    [SerializeField] private HeroCharacteristics _heroCaracteristics;
    private Slider _healthIndicatorSlider;

    private void Awake()
    {
        _healthIndicatorSlider = GetComponent<Slider>();
        _healthIndicatorSlider.maxValue = _heroCaracteristics.MaxHealth;
        _healthIndicatorSlider.wholeNumbers = false;
        _healthIndicatorSlider.value = _healthIndicatorSlider.maxValue;
    }

    private void OnEnable()
    {
        _heroCaracteristics.ChangeHealthPointsIndicator += OnHealthChanged;
    }

    private void OnDisable()
    {
        _heroCaracteristics.ChangeHealthPointsIndicator -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        _healthIndicatorSlider.value = health;
    }
}
