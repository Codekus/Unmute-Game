using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicProcessor : MonoBehaviour
{

    float[] audioBuffer;
    int[] spawnTabel;
    int[] usedTable;
    int currentState = 0;

    float volumeThreshHold = 0.3f;

    int bufferSize;
    private AudioClip audioClip;
    public AudioClip AudioClip
    {
        get { return audioClip; }
        set {
            //BEAT extraction BIS JETZT NUR BEAR , Erweitern um häufungs punkte für 3-4.... ect spawns hintereinander

            //rolling avg and resolution reduction 
            float[] volumeValues;
            audioClip = value;
            audioBuffer = new float[bufferSize];
            volumeValues = new float[(int)(audioClip.samples / bufferSize) + 1];
            for (int i = 0; i + bufferSize < audioClip.samples; i += bufferSize)
            {
                audioClip.GetData(audioBuffer, i);
                for (int x = 0; x < audioBuffer.Length; x++) {
                    volumeValues[i / bufferSize] += Math.Abs(audioBuffer[x]);
                }
                volumeValues[i / bufferSize] /= audioBuffer.Length;
            }

            int count = 0;
            //create spawn table        
            for (int i = 1; i < volumeValues.Length-1; i++) {
                if (volumeValues[i] == 0) continue;
                if (volumeValues[i - 1] < volumeValues[i] && volumeValues[i + 1] < volumeValues[i] && volumeValues[i] >= volumeValues[i])
                {
                    volumeValues[i - 1] = 0;
                    volumeValues[i + 1] = 0;
                    count++;
                }
                else {
                    volumeValues[i] = 0;
                }
            }

            spawnTabel = new int[count];
            count = 0;
            for (int i = 1; i < volumeValues.Length-1; i++) {
                if (volumeValues[i] != 0) {
                    spawnTabel[count] = i*bufferSize;
                    count++;
                }
            }

            reset();
        }
    }


    public MusicProcessor(int resolutionPerSec = 4) {
        bufferSize = 44100/ resolutionPerSec;
    }

    public void reset()
    {
        usedTable = (int[]) spawnTabel.Clone();
        currentState = 0;
        for (int i = 0; i < usedTable.Length; i++) {
            print(usedTable[i]);
        }
    }

    public bool getInformation(int sample) {
        //print(usedTable[currentState]+" "+sample);
        if (usedTable[currentState] < (int)(sample)) {
            currentState++;
            return true;
        }
        return false;
    }
}
