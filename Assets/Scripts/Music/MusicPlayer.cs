using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip music;
    AudioSource audioSource;
    MusicProcessor musicProcessor = new MusicProcessor(resolutionPerSec:6, volumeThreshHold:0.25f);
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = music;

        audioSource.volume = 1f;

        musicProcessor.AudioClip  = music;

        audioSource.Play();
    }

    public bool getInformation() {
        return musicProcessor.getInformation(audioSource.timeSamples);
    }


}
