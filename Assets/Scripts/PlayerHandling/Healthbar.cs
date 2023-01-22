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
    private GameObject _spawner;
    private float _maxHealth = 20;
    private float currentHealth;
    

    public void Start()
    {
        currentHealth = _maxHealth;
        updateHealthbar(_maxHealth, currentHealth);
        print("START HEALTHBAR CANVAS");
        print(_canvas);
        _canvas.enabled = false;
        _spawner = GameObject.Find("Spawner");
        updateHealthbar(_maxHealth, currentHealth);

        
        
    }

    public void updateHealthbar(float currentHealth, float maxHealth)
    {
        print(_healthbarSprite.fillAmount);
        print("current health in %: " + currentHealth / maxHealth);
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }

    public void onDeath()
    {
        print("DEAD");
        GameState.isDead = true;
        _canvas.enabled = true;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");
        Destroy(_spawner);
        foreach(GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
        
        foreach(GameObject weapon in weapons)
        {
            GameObject.Destroy(weapon);
        }
    }

    public void Heal()
    {
        currentHealth += 5f;
        if (currentHealth > _maxHealth)
        {
            currentHealth = _maxHealth;
        }
        updateHealthbar(currentHealth, _maxHealth);
    }

    public void hit()
    {
        currentHealth -= 1;
        updateHealthbar(currentHealth, _maxHealth);
        if (currentHealth <= 0)
        {
            onDeath();
        }
        print(currentHealth);
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public float getMaxHealth()
    {
        return _maxHealth;
    }

    private float timer = 0;
    
}
