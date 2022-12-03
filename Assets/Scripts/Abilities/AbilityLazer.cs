using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLazer : Ability
{
    
    private bool isRdy;
    private float timer = 0;

    [SerializeField] private Image _timerSprite;
    public override string getName()
    {
        
        return "lazer";
    }

    public override bool isReady()
    {
        throw new System.NotImplementedException();
    }

    public override void use()
    {
        if (!isRdy) return;
        print("lazer used");
        _timerSprite.fillAmount = 1;
        isRdy = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _timerSprite.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //_timerSprite.fillAmount = 1;
    }
}
