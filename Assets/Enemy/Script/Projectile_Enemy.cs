using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Platform.Samples.VrHoops;
using UnityEngine;
using UnityEngine.AI;

public class Projectile_Enemy : MonoBehaviour
{
     public float life = 3;
     private Vector3 position;


     Vector3 velocity;
     void Awake()
     {
         
        Destroy(gameObject,life);
    }
     
     void Start()
     {
        
        position = FindObjectOfType<BodyCollisionPlayer>().GetComponent<Transform>().position;
        position.y += 1f;
         velocity = (position - transform.position).normalized;
      
     }

     void Update()
     {
         transform.position += velocity * Time.deltaTime * 5.5f;
     }
}
