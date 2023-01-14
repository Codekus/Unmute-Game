using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    Vector3 rotation;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(Random.Range(0, 2), Random.Range(0, 2), Random.Range(0, 2));
        velocity = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime * -2;
        transform.Rotate(rotation, Random.Range(0, 5));
    }
}
