using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*
     * Start is called before the first frame update
     */
    [SerializeField] MusicPlayer musicPlayer;
    public GameObject[] types;
    public Transform[] points;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Entry entry = musicPlayer.getEntry();
        if (entry != null)
        {
            GameObject cube;
            if (entry.position != 0)
            {
                cube = Instantiate(types[entry.type], points[entry.position - 1]);
            }
            else
            {
                cube = Instantiate(types[entry.type], points[Random.Range(0, points.Length - 1)]);
            }
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 98 * Random.Range(0, 4));
        }
        else {
            /* open shop here
            * you can use musicPlayer.playNextSong(); to play the next song when the shop is closed    
            * for now the next round just starts after the song is finished
            * example below
            */
            if (!musicPlayer.isPlaying()) {
                if (musicPlayer.playNextSong() != -1)
                {
                    print("wave finished");
                }
                else
                {
                    print("last wave finished");
                }
            }
        }
    }
}
 