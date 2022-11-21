using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicProcessor : MonoBehaviour
{
    
    float[] audioBuffer;
    float[] volumeValues;
    float volumeThreshHold = 0.3f;

    int bufferSize;
    private AudioClip audioClip;
    public AudioClip AudioClip
    {
        get { return audioClip; }
        set {
            audioClip = value;
            audioBuffer = new float[bufferSize];
            volumeValues = new float[(int) (audioClip.samples / bufferSize) +1];
            for (int i = 0; i+bufferSize < audioClip.samples; i +=bufferSize)
            {
                audioClip.GetData(audioBuffer, i);
                for (int x = 0; x < audioBuffer.Length; x++) {
                    volumeValues[i / bufferSize] += Math.Abs(audioBuffer[x]);
                }
                volumeValues[i/ bufferSize] /= audioBuffer.Length;
            }
        }
    }

    public MusicProcessor(int resolution = 256) {
        bufferSize = resolution;
    }


    public bool getInformation(int sample) {
        if (volumeValues[(int)(sample / bufferSize)] > volumeThreshHold) {
            return true;
        }
        return false;
    }
}
