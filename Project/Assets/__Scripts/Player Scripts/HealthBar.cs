using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetHealth(float health)
    {
        slider.value = health;
        Debug.Log("13 Health: " + health);
        Debug.Log("14 SliderValue: " + slider.value);


    }

    public void SetMaxHealth(float health)
    {
        Debug.Log("21 MAXHealth: " + health);
        slider.maxValue = health;
        slider.value = health;

    }

}
