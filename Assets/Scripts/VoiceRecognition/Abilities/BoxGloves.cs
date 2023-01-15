using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxGloves : Ability
{
    [SerializeField] public GameObject boxLeft;
    [SerializeField] public GameObject boxRight;
    [SerializeField] public Rigidbody rBodyLeft;
    [SerializeField] public Rigidbody rBodyRight;
    [SerializeField] public Transform left;
    [SerializeField] public Transform right;

    public override string getName()
    {
        return "box";
    }

    // Start is called before the first frame update
    void Start()
    {
        rBodyLeft = boxLeft.GetComponent<Rigidbody>();
        rBodyRight = boxRight.GetComponent<Rigidbody>();
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
        boxLeft.SetActive(true);
        boxRight.SetActive(true);
    }

    public override bool isReady()
    {
        return true;
    }

    
    
}
