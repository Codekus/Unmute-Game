using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityShield : Ability
{
    private bool isRdy;
    private float timer = 0;
    [SerializeField] private Image _timerSprite;
    
    public override string getName()
    {
        return "shield";
    }

    public override bool isReady()
    {
        return isRdy;
    }

    public override void use()
    {
        if (!isRdy) return;
        print("shield used");
        
        isRdy = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        isRdy = true;
        _timerSprite.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRdy == false)
        {
            timer += Time.deltaTime * (1 / Time.timeScale);
            _timerSprite.fillAmount = 1 - (timer / 7);
        }
        if (timer > 7)
        {
            isRdy = true;
            timer = 0;
            _timerSprite.fillAmount = timer;
        }
    }
}
