using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSpaceStation : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f,0f,0.05f);
    }
}
