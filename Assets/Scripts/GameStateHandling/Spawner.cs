using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    /*
     * Start is called before the first frame update
     */
    [SerializeField] public MusicPlayer musicPlayer;
    [SerializeField] private Canvas upgradeMenu;
    [SerializeField] private Transform playHitBox;
    //This means it is 6 times more likely the first item will be spawned
    [SerializeField] public int scewTowardsFirstObstacle = 3;
    public GameObject[] types;
    public Transform[] points;
    float timer = 0;
    void Start()
    {
        upgradeMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.gamePaused) return;

        Entry entry = musicPlayer.getEntry((int) (441000*GameState.timeScale));
        
        if (entry != null)
        {
            if (entry.type == 1000) entry.type = 5;
            GameObject cube;
            int type = 0;
            if (entry.type == 999)
            {
                //scews probability towards the first obstacle type
                type = Random.Range(0, types.Length + types.Length * scewTowardsFirstObstacle);
                if (type >= types.Length) type = 0;
            }
            else
            {
                
                type = entry.type;
            }

            if (entry.position != 0)
            {
                cube = Instantiate(types[type], points[entry.position - 1]);
            }
            else
            {
                cube = Instantiate(types[type], points[Random.Range(0, points.Length - 1)]);
            }
            if (type == 5)
            {
                MyEnemyController enemieScript = cube.GetComponent<MyEnemyController>();
                enemieScript.pointA = points[3];
                enemieScript.pointB = points[5];
                enemieScript.playerObj = playHitBox;
            }
            else {
                cube.transform.localPosition = Vector3.zero;
                cube.transform.Rotate(transform.forward, 98 * Random.Range(0, 4));
            }
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
                    GameState.gamePaused = true;
                    upgradeMenu.enabled = true;
                }
                else
                {
                    print("last wave finished");
                }
            }
        }
    }
}
 