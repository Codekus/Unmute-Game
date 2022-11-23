using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip music;
    [SerializeField] bool loadFromFiles = false;
    [SerializeField] string fileName = "name";
    AudioSource audioSource;
    MusicProcessor musicProcessor = new MusicProcessor(resolutionPerSec:6, volumeThreshHold:0.25f);
    State state;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 1f;

        if (loadFromFiles)
        {
            MapEditor me = new MapEditor();
            state = new State(me.loadMap(fileName));
            audioSource.clip = me.music;
        }
        else
        {
            musicProcessor.AudioClip = music;
            state = new State(musicProcessor.cloneSpawnTable());
            audioSource.clip = music;
        }
        audioSource.Play();
    }

    public bool getInformation() {
        return state.getInformation(audioSource.timeSamples);
    }

}
