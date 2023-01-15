using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Enemy : MonoBehaviour
{
     public float life = 3;


     Vector3 velocity;
     void Awake()
    {
        Destroy(gameObject,life);
    }
     
     void Start()
     {
         velocity = new Vector3(0, 0.71f, 1);
     }

     void Update()
     {
         transform.position += velocity * Time.deltaTime * -2;
     }
}
