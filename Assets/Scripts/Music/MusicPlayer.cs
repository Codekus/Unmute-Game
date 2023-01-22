using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip music;
    [SerializeField] bool loadFromFiles = false;
    [SerializeField] string[] songList;
    AudioSource audioSource;
    MusicProcessor musicProcessor = new MusicProcessor(resolutionPerSec:6, volumeThreshHold:0.25f);
    State state;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.volume = 1f;
        audioSource.loop = false;

        //this should be called when the main menu is closed
        playSong(GameState.wave);
    }

    private void Update()
    {
        audioSource.pitch = Time.timeScale;
    }

    public bool isPlaying() {
        return audioSource.isPlaying;
    }

    public Entry getEntry(int delayInSamples) {
        return state.getEntry(audioSource.timeSamples + delayInSamples);
    }

    public int playNextSong() {
        GameState.wave++;
        GameState.timeScale += 0.05f;
        return playSong(GameState.wave);
    }

    public int playSong(int index)
    {
        index %= songList.Length;

        if (index >= songList.Length)
        {
            return -1;
        }

        if (loadFromFiles)
        {
            MapEditor me = new MapEditor();
            state = new State(me.loadMap(songList[index]));
            audioSource.clip = me.music;
        }
        else
        {
            musicProcessor.AudioClip = music;
            state = new State(musicProcessor.cloneSpawnTable());
            audioSource.clip = music;
        }
        audioSource.Play();

        return index;
    }

}
