using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Ability : MonoBehaviour
{
    public abstract void use();
    public abstract string getName();

    public abstract bool isReady();

    
}
