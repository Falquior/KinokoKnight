using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    private Slider slider;
    FalPlantScript plantData;

    public void Start()
    {
        slider = GetComponent<Slider>();     
        plantData = FindAnyObjectByType<FalPlantScript>();
    }
    private void Update()
    {
        SetHealth(plantData.life);
    }

    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    // Call this method in Boss script inserting health / LIFE argument.
    // In Start and update? Maybe calling them individualy insted of using this method. As you wish.
    public void InitializeHealth(float health, float maxHealth)
    {
        SetMaxHealth(maxHealth);
        SetHealth(health);
    }


}
