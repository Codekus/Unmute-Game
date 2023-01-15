using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGlovesCollision : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Enemy"))
        {
            GameState.ememieDestoyed();
            Destroy(other.gameObject);
            
        }
    }
}
