using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbiltySlowdown : Ability
{
    private bool isRdy;
    private float timer = 0;
    public float timeScale = 0.7f;
    [SerializeField] private Image _timerSprite;
    public override string getName()
    {
        return "slowdown";
    }

    public override bool isReady()
    {
        return isRdy;
    }

    public override void use()
    {
        if (!isRdy) return;
        Time.timeScale = timeScale;
        print("slow");
        
        isRdy = false;
        
    }

    public void reduceTimeScale()
    {
        timeScale -= 0.2f;
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
            _timerSprite.fillAmount = 1 - (timer / 15);
        }
        if (timer > 15)
        {
            isRdy = true;
            timer = 0;
            _timerSprite.fillAmount = timer;
        }
    }
}
