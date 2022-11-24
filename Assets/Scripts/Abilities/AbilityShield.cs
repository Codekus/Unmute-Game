using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShield : Ability
{
    private bool isRdy;
    private float timer = 0;
    
    public override string getName()
    {
        return "shield";
    }

    public override bool isReady()
    {
        throw new System.NotImplementedException();
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
