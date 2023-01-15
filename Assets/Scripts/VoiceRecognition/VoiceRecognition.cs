using UnityEngine;
using Vosk;
using System;
using System.Collections.Generic;

public class VoiceRecognition : MonoBehaviour
{
    [SerializeReference] List<Ability> keyWordEvents = new List<Ability>();
    
    //das hier ist warscheinlich �berfl�ssig sorgt aber f�rs erst f�r keine doppel aufrufe 
    //da KeyWord recognition auf "fertigen" und "nicht fertigen" Phrasen gleichzeitig l�uft gibt es mehrfach aufrufe sorgt jedoch f�r bessere Response time
    //durch coolDown der f�higkeiten �berfl�ssig
    float timer = 0;
    float onKeyWordLastUsed = 0;
    float onKeyWordCoolDown = 0.35f;
    public void onKeyWord(int keyWord)
    {
        
        if (keyWord == -1 || keyWord > keyWordEvents.Count) { return; }

        if (timer - onKeyWordLastUsed > onKeyWordCoolDown)
        {
            keyWordEvents[keyWord].use();
            onKeyWordLastUsed = timer;
        }
    }


    [SerializeField] private int bufferSize = 512;
    [SerializeField] private int sampleRate = 16000;
    [SerializeField] private string modelPath = "Assets\\LangModels\\vosk-model-en-us-0.22-lgraph";


    string keyWords;
    VoskRecognizer recognizer;
    private string device;
    private AudioClip audioClip;

    private float[] buffer;
    private int micLastPosition = 0;


    void Start()
    {
        Ability a = new AbilityLazer();
        print(Microphone.devices[0]);
        if (device == null) device = Microphone.devices[0];
        micLastPosition = Microphone.GetPosition(device);
        audioClip = Microphone.Start(device, true, 999, sampleRate);
        print("MIC LAST POSITION IS: " + micLastPosition);
        Model model = new Model(modelPath);
        //KeyWords in JSON format
        keyWords = "[";
        for (int i = 0; i < keyWordEvents.Count; i++)
        {
            if (model.FindWord(keyWordEvents[i].getName()) == -1) {
                print("Wort: " + keyWordEvents[i].getName() + " NICHT im Model enthalten");
            }
            keyWords += "\"" + keyWordEvents[i].getName() + "\",";
        }
        keyWords += "\"[unk]\"]";

        //Damit man nochmal sieht was alles in den Sprache ist
        print(keyWords);


        recognizer = new VoskRecognizer(model, sampleRate, keyWords);
        recognizer.SetMaxAlternatives(0);
        recognizer.SetWords(true);

        buffer = new float[bufferSize];
    }

    void Update()
    {
        if(GameState.gamePaused) return;
        timer += Time.deltaTime;

        int micPosition = Microphone.GetPosition(null);
        
        //schneides maximal 127 sampel hinten weg durch % operator auf endedes mic buffers ist wrap around m�glich hab ich aber keine lust zu schreiben
        if (micPosition < micLastPosition) {
            micLastPosition = micPosition;
        }

        if (micPosition - micLastPosition < bufferSize)
        {
            return;
        }
        
        int samplePos = micLastPosition + (bufferSize);
        audioClip.GetData(buffer, samplePos);

        short[] byteBuffer = new short[bufferSize];
        for (int i = 0; i < bufferSize; i++)
        {
            byteBuffer[i] = (short)Math.Floor(buffer[i] * short.MaxValue);
        }

        if (recognizer.AcceptWaveform(byteBuffer, byteBuffer.Length))
        {
            if (recognizeKeyWord(recognizer.Result()) != -1) {
                recognizer.Reset();
            }
        }
        else
        {
            if (recognizeKeyWord(recognizer.PartialResult()) != -1) {
                recognizer.Reset();
            }
        }

        micLastPosition = samplePos;
    }

    public int recognizeKeyWord(string result) {
        
        for (int i = 0; i < keyWordEvents.Count; i++) {
            if (result.ToLower().Contains(keyWordEvents[i].getName().ToLower())) {
                onKeyWord(i);
                return i;
            }
        }
        
        return -1;
    }


    private void OnDestroy()
    {
        Microphone.End(device);
    }

}
