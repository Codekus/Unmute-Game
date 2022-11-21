using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLazer : Ability
{

    public override string getName()
    {
        return "lazer";
    }

    public override void use()
    {
        print("lazer used");
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
