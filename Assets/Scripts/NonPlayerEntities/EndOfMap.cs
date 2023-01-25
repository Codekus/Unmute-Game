using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndOfMap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy")) print("combo reset");
        if (other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("Weapon")){
            Destroy(other.gameObject);
         }
        
    }
}
