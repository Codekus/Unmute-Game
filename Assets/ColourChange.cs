using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class ColourChange : MonoBehaviour
    {

        public Color myColor;
        public float rFloat;
        public float gFloat;
        public float bFloat;
        public float aFloat;

        public Renderer myRenderer;
        // Start is called before the first frame update
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

        public void updateColour()
        {
            
            myColor = new Color(0f, 0.5f, 0.5f, 1f);
            Debug.Log(myColor);
            myRenderer.material.color = myColor;
        }

        
    }
}

