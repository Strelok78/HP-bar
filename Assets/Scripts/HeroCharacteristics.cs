using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroCharacteristics : MonoBehaviour
{
    public event UnityAction<float> HealthChanged;

    [SerializeField] private float _maxHealth;

    private float _currrentHealth;
    private float _minHealth = 0;

    public float MaxHealth { get { return _maxHealth; } }

    private void Awake()
    {
        _currrentHealth = _maxHealth;
    }

    public void ChangeHealth(float healthChange)
    {
        _currrentHealth += healthChange;
        _currrentHealth = Mathf.Clamp(_currrentHealth, _minHealth, _maxHealth);
        HealthChanged?.Invoke(_currrentHealth);
    }
}
