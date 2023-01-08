using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class MyEnemyController : MonoBehaviour
{
    public Transform playerObj;
    
    protected NavMeshAgent enemyMesh;
    

    public float health;

    
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttecked;
    public GameObject projectile;
   
    
    //States
    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
          transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.PingPong(Time.time * speed, 1));
       
          transform.LookAt(playerObj);
        

        if(!alreadyAttecked)
      {
        Vector3 shotDirection = playerObj.position - transform.position;
        GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);
        Rigidbody rb = projectileInstance.GetComponent<Rigidbody>();
        rb.velocity = shotDirection;


        alreadyAttecked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
      }
    }
    
   
    
    
        
    
    private void ResetAttack()
    {
        alreadyAttecked = false;
    }
    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
   
    
}


    

