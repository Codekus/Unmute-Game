using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    Vector3 rotation;
    Vector3 velocity;
    [SerializeField] private GameObject ParticlePrefab;
    
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource source;
    
    
 
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

    void OnDestroy()
    {
        source.PlayOneShot(clip);
        if(!GameState.isDead) AudioSource.PlayClipAtPoint(clip, transform.position);
        SpawnParticle();
    }
    
    void SpawnParticle() {
        // Create an instance of the particle system prefab at the position (0, 0, 0)
        // with a rotation of (0, 0, 0)
        
        GameObject particle = Instantiate(ParticlePrefab, transform.position, Quaternion.identity);

        // You can also set the position and rotation of the particle system when you spawn it
        // For example, to spawn the particle system at (1, 2, 3) with a rotation of (45, 0, 0)
    }
}
