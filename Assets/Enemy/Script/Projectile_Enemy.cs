using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Enemy : MonoBehaviour
{
     public float life = 3;

    void Awake()
    {
        Destroy(gameObject,life);
    }
}
