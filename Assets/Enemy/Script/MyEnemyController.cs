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
    private float shootTimer = 0;
   
    
    //States
    public Transform pointA;
    public Transform pointB;
    public float speed = 1f;

    private Vector3 playerPos;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyMesh = GetComponent<NavMeshAgent>();
        InvokeRepeating("Fire", 0f, 3f);
        playerPos = new Vector3(0, -1, 0);


    }

    // Update is called once per frame
    void Update()
    {
        
          transform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.PingPong(Time.time * speed, 1));
       
          transform.LookAt(playerObj);
        

        if(shootTimer >= timeBetweenAttacks)
      {
          shootTimer = 0;
          /*     transform.position = Vector3.MoveTowards(transform.position, playerPos, 100f * Time.deltaTime);
               Vector3 direction = (playerObj.position - transform.position).normalized;
               GameObject bullet = Instantiate(projectile, transform.position, Quaternion.LookRotation(direction));
               bullet.GetComponent<Transform>().position = Vector3.MoveTowards(transform.position, playerPos, 100f * Time.deltaTime);
               
                 Vector3 shotDirection = (playerObj.position - transform.position).normalized;
                 GameObject projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity);
                 Rigidbody rb = projectileInstance.GetComponent<Rigidbody>();
                 projectileInstance.GetComponent<Rigidbody>().AddForce(shotDirection * 1.25f);
                 //rb.velocity = shotDirection;
                 */
            
           // rb.transform.Translate(shotDirection * Time.deltaTime);
            


      //      alreadyAttecked = true;
      //      Invoke(nameof(ResetAttack), timeBetweenAttacks);
      }
        else
        {
            shootTimer += Time.deltaTime * (1 / Time.timeScale);
        }
    }
    
    void Fire() {
        print("shoot");
        print(playerPos);
        
        Vector3 playerPosition = playerObj.position;
        playerPosition.y = playerPosition.y + 1;
        Vector3 direction = (playerPosition - transform.position).normalized;
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(direction * 300f);
        //bullet.GetComponent<Rigidbody>().velocity = playerPosition * 100f;

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


    

