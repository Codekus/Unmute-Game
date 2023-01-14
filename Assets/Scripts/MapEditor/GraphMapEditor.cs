using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphMapEditor : MonoBehaviour
{
    MusicProcessor musicProcessor = new MusicProcessor(resolutionPerSec: 100);
    [SerializeField] AudioClip music;
    [SerializeField] Sprite circleSprite;
    [SerializeField] RectTransform graphContainer;
    [SerializeField]LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Awake()
    {/*
        musicProcessor.AudioClip = music;


        int x = musicProcessor.AudioClip.samples;
        float[] volumeValues = musicProcessor.getVolVals();
        lineRenderer.sortingOrder = 1;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.color = Color.blue;

        for (int i = 0; i < volumeValues.Length; i++) {
            if (volumeValues[i] != 0) {
                lineRenderer.SetPosition(lineRenderer.positionCount++, new Vector2(graphContainer.rect.width * i / volumeValues.Length, volumeValues[i] * graphContainer.rect.height));
            }
                //
        }
        int[] spawnTable = musicProcessor.getSpawnTable();
        for (int i = 0; i < spawnTable.Length; i++) {
            int val = spawnTable[i];
            createCircle(new Vector2(val/musicProcessor.getSampleSize(), volumeValues[i/musicProcessor.getBufferSize()]));
        }*/
    }
    
    private void createCircle(Vector2 anchoredPosition, float size = 1) {
        GameObject gameObject = new("Circle", typeof(Image));
        gameObject.transform.SetParent(lineRenderer.transform, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = graphContainer;
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(size, size);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
