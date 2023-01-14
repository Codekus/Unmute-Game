using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbiltySlowdown : Ability
{
    private bool isRdy;
    private float timer = 0;
    private float timeScale = 0.3f;
    [SerializeField] private Image _timerSprite;
    private int maxLevel = 2;
    private int currentLevel = 0;
    private bool isActive;
    private float isActiveTimer;
    private float slowDuration = 3;
    public override string getName()
    {
        return "slowdown";
    }
    public int getMaxlvl()
    {
        return maxLevel;
    }
    public int getCurrentLvl()
    {
        return currentLevel;
    }

    public void lvlUp()
    {
        currentLevel++;
    }

    public override bool isReady()
    {
        return isRdy;
    }

    public override void use()
    {
        if (!isRdy) return;
        Time.timeScale = timeScale * GameState.timeScale;
        print("slow");
        isRdy = false;
        isActiveTimer = 0.0f;

    }

    public void increaseDuration()
    {
        slowDuration += 1.0f;
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
        isActiveTimer += Time.deltaTime * (1 / Time.timeScale);
        if (isActiveTimer > slowDuration)
        {
            Time.timeScale = GameState.timeScale;
        }   
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
