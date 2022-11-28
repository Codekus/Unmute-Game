using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image _healthbarSprite;

    public void updateHealthbar(float currentHealth, float maxHealth)
    {
        print("current health in %: " + currentHealth / maxHealth);
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }

    
}
