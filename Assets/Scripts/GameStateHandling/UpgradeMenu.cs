using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    // Start is called before the first frame update

    
    [SerializeField] private Canvas menu;
    private bool upgradeUsed = false;

    [SerializeField] private GameObject laserLvl;
    [SerializeField] private GameObject shieldLvl;
    [SerializeField] private GameObject slowdownLvl;
    [SerializeField] private Healthbar healthBar;

    [SerializeField] private AbilityLazer abilityLazer;
    [SerializeField] private AbilityShield abilityShield;
    [SerializeField] private AbiltySlowdown abiltySlowdown;

    private BodyCollision bodyCollision; 
    
    
    public Image laserImg;
    public Image shieldImg;
    public Image slowdownImg;

    void Start()
    {
        SetLvlText();
    }

    private void SetLvlText()
    {
        laserLvl.GetComponent<TextMeshProUGUI>().SetText(abilityLazer.getCurrentLvl() + " / " + abilityLazer.getMaxlvl());
        shieldLvl.GetComponent<TextMeshProUGUI>().SetText(abilityShield.getCurrentLvl() + " / " + abilityShield.getMaxlvl());
        slowdownLvl.GetComponent<TextMeshProUGUI>().SetText(abiltySlowdown.getCurrentLvl() + " / " + abiltySlowdown.getMaxlvl());
    }

    // Update is called once per frame

    public void UpgradeLaser()
    {
        if (upgradeUsed) return;
        if (abilityLazer.getCurrentLvl() == abilityLazer.getMaxlvl())
        {
            return;
        }
        abilityLazer.lvlUp();
        SetLvlText();
        abilityLazer.setMaxCooldown(abilityLazer.getMaxCooldown() - 2);
        upgradeUsed = true;
        //      menu.enabled = false;

    }
    
    public void UpgradeShield()
    {
        if (upgradeUsed) return;
        if (abilityShield.getCurrentLvl() == abilityShield.getMaxlvl())
        {
            return;
        }
        abilityShield.lvlUp();
        SetLvlText();
        upgradeUsed = true;
 //       menu.enabled = false;
    }
    
    public void UpgradeSlowdown()
    {
        if (upgradeUsed) return;
        if (abiltySlowdown.getCurrentLvl() == abiltySlowdown.getMaxlvl())
        {
            return;
        }
        abiltySlowdown.lvlUp();
        SetLvlText();
        abiltySlowdown.increaseDuration();
        upgradeUsed = true;
//        menu.enabled = false;
    }

    public void Continue()
    {
        GameState.gamePaused = false;
        menu.enabled = false;
        upgradeUsed = false;
    }

    public void Heal()
    {
        healthBar.Heal();
    }
    
    
    
}
