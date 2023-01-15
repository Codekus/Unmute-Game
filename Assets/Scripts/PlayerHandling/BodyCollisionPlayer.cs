using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollisionPlayer : MonoBehaviour
{
    
    public Transform head;
    public Transform feet;
    [SerializeField] private Healthbar _healthbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(head.position.x, head.position.y-1, head.position.z);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        print("got hit ");
        if (other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("Weapon") )
        {
            print("hit" + other.gameObject);
            Destroy(other.gameObject);
            _healthbar.hit();
        }
    }
}
