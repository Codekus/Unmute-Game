using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Entry 
{

    [SerializeField]
    public int sample = 0;
    [SerializeField]
    public int type = 0;
    //position 0-9 0=Random 1-9 grid position
    [SerializeField]
    public int position = 0;

    public Entry() { }
    public Entry(int sample, int type, int position)
    {
        this.sample = sample;
        this.type = type;
        this.position = position;
    }
    
}
