using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColour : MonoBehaviour
{
    
    public Renderer myRenderer;
    // Start is called before the first frame update
    public Color myColor;
    public float rFloat;
    public float gFloat;
    public float bFloat;
    public float aFloat;
    void Start()
    {
        myColor = new Color(1f, 0.5f, 0.5f, 1f);
        aFloat = 1;
        myRenderer = gameObject.GetComponent<Renderer>();
        myRenderer.material.color = myColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
