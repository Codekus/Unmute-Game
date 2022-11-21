using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip music;
    AudioSource audioSource;
    MusicProcessor musicProcessor = new MusicProcessor(320);
    float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = music;

        audioSource.volume = 0.5f;

        musicProcessor.AudioClip  = music;

        audioSource.Play();
    }

    public bool getInformation() {
        return musicProcessor.getInformation(audioSource.timeSamples);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        timer += Time.deltaTime;
        if (timer > 0.025)
        {
            timer = 0;
            musicProcessor.getInformation(audioSource.timeSamples);
        }*/
    }
}
