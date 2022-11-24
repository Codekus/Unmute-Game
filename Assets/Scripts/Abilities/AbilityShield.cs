using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShield : Ability
{
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
        print("shield used");
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
