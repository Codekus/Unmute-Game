using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] MusicPlayer musicPlayer;
    public GameObject[] cubes;
    public Transform[] points;
    private float timer;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (musicPlayer.getInformation())
        {
            GameObject cube = Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0, 4)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 98 * Random.Range(0, 4));
        }

        timer += Time.deltaTime;
    }
}
 