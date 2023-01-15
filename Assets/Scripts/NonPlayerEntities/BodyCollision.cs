using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollision : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform head;
    public Transform feet;
    [SerializeField] private Healthbar _healthbar;
    private CapsuleCollider CapsuleCollider;

    void Start() 
    {
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals("Enemy"))
        {
            GameState.multiplyer = 1;
            Destroy(other.gameObject);
            _healthbar.hit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //gameObject.transform.rotation = new Quaternion(head.rotation.x, head.rotation.y, head.rotation.z, 0);
    }
    
    
    
}
