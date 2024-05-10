using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehavior : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(float health, float maxHealth)
    {

        slider.maxValue = maxHealth;
        slider.value = health;
    }
}
