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

    public Entry getEntry(int sample)
    {
        if (currentState >= table.Length) return null;
        //print(usedTable[currentState]+" "+sample);
        if (table[currentState].sample < (int)(sample))
        {
            return table[++currentState];
        }
        return null;
    }

}
