using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    private Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();     
    }

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    // Call this method in Boss script inserting health / LIFE argument.
    // In Start and update? Maybe calling them individualy insted of using this method. As you wish.
    public void InitializeHealth(int health)
    {
        SetMaxHealth(health);
        SetHealth(health);
    }


}
