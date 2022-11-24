using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbiltySlowdown : Ability
{
    private bool isRdy;
    private float timer = 0;
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
        Time.timeScale = 0.5f;
        print("slow");
        isRdy = false;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRdy == false)
        {
            timer += Time.deltaTime * (1 / Time.timeScale);
        }
        if (timer > 15)
        {
            isRdy = true;
            timer = 0;
            print("ready");
        }
    }
}
