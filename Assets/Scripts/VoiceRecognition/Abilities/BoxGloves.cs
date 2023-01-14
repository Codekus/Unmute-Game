using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxGloves : Ability
{
    [SerializeField] GameObjetct boxLeft;
    [SerializeField] GameObjetct boxRight;
    [SerializeField] Rigidbody rBodyLeft;
    [SerializeField] Rigidbody rBodyRight;
    [SerializeField] Transform left;
    [SerializeField] Transform right;
    
    public override string getName()
    {
        return "box";
    }
    
    // Start is called before the first frame update
    void Start()
    {
        rBodyLeft = GetComponent<Rigidbody>();
        rBodyRight = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    
    void Update()
    {
        rBodyRight.MovePosition(right.transform.position);
        rBodyLeft.MovePosition(left.transform.position);
        rBodyRight.MoveRotation(right.transform.rotation);
        rBodyLeft.MoveRotation(left.transform.rotation);
    }

    public override void use()
    {
        //boxLeft.enabled = true;
        //boxRight.enabled = true;
    }

    public override bool isReady()
    {
        return true;
    }
}
