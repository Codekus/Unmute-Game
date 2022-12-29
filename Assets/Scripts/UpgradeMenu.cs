using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    
    
    private AbilityLazer abilityLazer;
    
    
    private AbilityShield abilityShield;
    
    
    private AbiltySlowdown abiltySlowdown;
    // Start is called before the first frame update

    [SerializeField] private GameObject vosk;
    
    [SerializeField] private Canvas menu;
    void Start()
    {
        abilityLazer = vosk.GetComponent<AbilityLazer>();
        abilityShield = vosk.GetComponent<AbilityShield>();
        abiltySlowdown = vosk.GetComponent<AbiltySlowdown>();
    }

    // Update is called once per frame

    public void UpgradeLaser()
    {
        abilityLazer.setMaxCooldown(abilityLazer.getMaxCooldown() - 2);
        menu.enabled = false;

    }
    
    public void UpgradeShield()
    {
        menu.enabled = false;
    }
    
    public void UpgradeSlowdown()
    {
        print("HEYHEYHEY");
        abiltySlowdown.reduceTimeScale();
        menu.enabled = false;
    }
}
