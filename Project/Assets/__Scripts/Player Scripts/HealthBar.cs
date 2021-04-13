using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;//reference to the slider

    public void SetHealth(float health)//to set the health slider's value
    {
        slider.value = health;

    }

    public void SetMaxHealth(float health)//to set the health slider's max value of health, called if it goes above the max health
    {
        slider.maxValue = health;
        slider.value = health;

    }

}
