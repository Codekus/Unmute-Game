using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layer;
    private Vector3 previousPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            if(hit.transform.gameObject.tag.Equals("Enemy"))
            {
                GameState.ememieDestoyed();
                Destroy(hit.transform.gameObject);
            }
            
            /*
            if (Vector3.Angle(transform.position - previousPos, hit.transform.up) > 130)
            {
                
            }
            */
            
        }

        previousPos = transform.position;
    }
}
