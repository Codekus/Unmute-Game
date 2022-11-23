using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position +=  new Vector3(Time.deltaTime,1,1) + transform.forward ;
        Vector3 velocity = new Vector3(0,0,1);
        transform.Translate(velocity * Time.deltaTime * -2);
        //Debug.Log(transform.position);
    }
}
