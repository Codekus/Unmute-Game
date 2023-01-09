using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using static MusicProcessor;

public class MapEditor : MonoBehaviour
{
    [Serializable]
    public enum Mode
    {
        NewMap,
        AutoGenerate,
        Load
    }
    [SerializeField] Mode mode = Mode.NewMap;
    [Header("Songname for New/Autogenerate")]
    [SerializeField] string songName = "badapple";
    [Header("Mapname for loading")]
    [SerializeField] string mapName = "badapple";
    [Header("Autogenerate Settings")]
    [SerializeField] int resolutionPerSec = 6;
    [SerializeField] float volumeThreshHold = 0.25f;
    [SerializeField] int samplingRate = 44100;
    string path = "Music\\";
    [Header("Shows if music could be loaded dont touch")]
    [SerializeField] public AudioClip music;
    [SerializeReference] Entry[] spawnTable;
    MusicProcessor musicProcessor;
    [SerializeField] string saveAs = "name";
    [SerializeField] bool save = false;
    // Start is called before the first frame update
    void Start()
    {
        if (mode == Mode.AutoGenerate) {
            musicProcessor = new MusicProcessor(resolutionPerSec, volumeThreshHold, samplingRate);
            music = Resources.Load(path + songName) as AudioClip;
            musicProcessor.AudioClip = music;
            spawnTable = musicProcessor.cloneSpawnTable();
            return;
        }

        if (mode == Mode.NewMap) {
            music = Resources.Load(path + songName) as AudioClip;
            spawnTable = new Entry[] { new Entry()};

            return;
        }

        if (mode == Mode.Load) {
            loadMap(mapName);
        }
    }

    public Entry[] loadMap(string mapName) {
        String pattern = @"\d+";
        string filePath = Application.dataPath + "\\Resources\\" + path + mapName + ".map_file";
        StreamReader sr = new StreamReader(filePath);
        String name = sr.ReadLine();
        music = Resources.Load(path + name) as AudioClip;
        List<Entry> arrL = new List<Entry>();
        string s;
        while ((s = sr.ReadLine()) != null) {
            MatchCollection m = Regex.Matches(s, pattern);
            if (m.Count == 3) {
                arrL.Add(new Entry(int.Parse(m[0].Value),int.Parse(m[1].Value),int.Parse(m[2].Value)));
            }
        }

        spawnTable = new Entry[arrL.Count];
        for(int i = 0; i < arrL.Count; i++)
        {
            spawnTable[i] = arrL[i];
        }
        return spawnTable;
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spawnTable.Length; i++)
        {
            if (spawnTable[i] == null)
            {
                if(!(i == 0)) {
                    spawnTable[i] = new Entry();
                    spawnTable[i].sample = spawnTable[i - 1].sample + 1;
                }
            }

        }
        sort(spawnTable);

        if (save) {
            saveMap();
        }
    }

    void saveMap()
    {
        save = false;
        print("Saved");
        string filePath = Application.dataPath + "\\Resources\\" + path + saveAs+ ".map_file";
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        StreamWriter outStream = new StreamWriter(filePath);
        outStream.WriteLine(songName);

        outStream.Write("[" + spawnTable[0].sample + "," + spawnTable[0].type +"," + spawnTable[0].position + "]\n");
        for (int i = 1; i < spawnTable.Length; i++) {
            outStream.Write("["+spawnTable[i].sample+","+spawnTable[i].type+ "," + spawnTable[i].position+"]\n");
        }
        outStream.Close();

    }

    void sort(Entry[] table)
    {
        while (!isSorted(table))
        {
            for (int i = 1; i < spawnTable.Length; i++)
            {
                if (spawnTable[i-1].sample > spawnTable[i].sample) {
                    Entry e1 = spawnTable[i - 1];
                    spawnTable[i - 1] = spawnTable[i];
                    spawnTable[i] = e1;
                }
            }
        }

    }

    bool isSorted(Entry[] table)
    {
        for (int i = 1; i < spawnTable.Length; i++)
        {
            if (table[i-1].sample > table[i].sample) return false;
        }
        return true;
    }


}
