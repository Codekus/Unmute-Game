using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    
    
    private AbilityLazer abilityLazer;
    
    
    private AbilityShield abilityShield;
    
    
    private AbiltySlowdown abiltySlowdown;
    // Start is called before the first frame update

    [SerializeField] private GameObject vosk;
    
    [SerializeField] private Canvas menu;

    [SerializeField] private GameObject laserLvl;
    [SerializeField] private GameObject shieldLvl;
    [SerializeField] private GameObject slowdownLvl;
    [SerializeField] private Healthbar healthBar;
    private BodyCollision bodyCollision; 
    
    
    public Image laserImg;
    public Image shieldImg;
    public Image slowdownImg;
    
    void Start()
    {
    //    abilityLazer = vosk.GetComponent<AbilityLazer>();
        abilityShield = vosk.GetComponent<AbilityShield>();
        abiltySlowdown = vosk.GetComponent<AbiltySlowdown>();
        SetLvlText();
    }

    private void SetLvlText()
    {
    //    laserLvl.GetComponent<TextMeshProUGUI>().SetText(abilityLazer.getCurrentLvl() + " / " + abilityLazer.getMaxlvl());
        shieldLvl.GetComponent<TextMeshProUGUI>().SetText(abilityShield.getCurrentLvl() + " / " + abilityShield.getMaxlvl());
        slowdownLvl.GetComponent<TextMeshProUGUI>().SetText(abiltySlowdown.getCurrentLvl() + " / " + abiltySlowdown.getMaxlvl());
    }

    // Update is called once per frame

    public void UpgradeLaser()
    {
        print(abilityLazer.getCurrentLvl() + " / " + abilityLazer.getMaxlvl());
        if (abilityLazer.getCurrentLvl() == abilityLazer.getMaxlvl())
        {
            return;
        }
        abilityLazer.lvlUp();
        SetLvlText();
        abilityLazer.setMaxCooldown(abilityLazer.getMaxCooldown() - 2);
  //      menu.enabled = false;

    }
    
    public void UpgradeShield()
    {
        if (abilityShield.getCurrentLvl() == abilityShield.getMaxlvl())
        {
            return;
        }
        abilityShield.lvlUp();
        SetLvlText();
 //       menu.enabled = false;
    }
    
    public void UpgradeSlowdown()
    {
        if (abiltySlowdown.getCurrentLvl() == abiltySlowdown.getMaxlvl())
        {
            return;
        }
        abiltySlowdown.lvlUp();
        SetLvlText();
        abiltySlowdown.increaseDuration();
//        menu.enabled = false;
    }

    public void Continue()
    {
        menu.enabled = false;
    }

    public void Heal()
    {
        healthBar.Heal();
    }
    
    
    
}
