using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    int currentState = 0;
    Entry[] table;
    public State(Entry[] table)
    {
        this.table = table;
    }

    public bool getInformation(int sample)
    {
        if (currentState >= table.Length) return false;
        //print(usedTable[currentState]+" "+sample);
        if (table[currentState].sample < (int)(sample))
        {
            currentState++;
            return true;
        }
        return false;
    }

}
