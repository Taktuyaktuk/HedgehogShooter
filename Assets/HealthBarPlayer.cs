using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Slider HealthSlider;

    public void SetMaxHealth(float health)
    {
        HealthSlider.maxValue = health;
    }

    public void SetHealth(float health)
    {
        HealthSlider.value = health;
    }
}
