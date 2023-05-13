using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HP_bar : MonoBehaviour
{
    Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void Damage(float damage)
    {
        if (slider != null && slider.value != slider.minValue)
        {
            slider.value -= damage;
        }
    }

    public void Heal(float heal)
    {
        if(slider != null && slider.value != slider.maxValue)
        {
            slider.value += heal;
        }
    }
}
