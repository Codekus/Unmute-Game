using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image _healthbarSprite;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Spawner _spawner;
    

    public void Start()
    {
        _canvas.enabled = false;
    }

    public void updateHealthbar(float currentHealth, float maxHealth)
    {
        print("current health in %: " + currentHealth / maxHealth);
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }

    public void onDeath()
    {
        _canvas.enabled = true;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Destroy(_spawner);
        foreach(GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
    }

    public void Heal()
    {
        
    }
    
    

    
}
