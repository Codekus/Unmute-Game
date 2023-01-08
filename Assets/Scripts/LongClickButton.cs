using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private bool pointerDown;

    private float pointerDownTimer;

    private float requiredHoldTime = 1;

    public UnityEvent onLongClick;

    [SerializeField] private Image fillImage;
    public GameObject ParticlePrefab;

    public AudioClip clip;
    public AudioSource source;

    public void Start()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("OnPointerUp");
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer > requiredHoldTime)
            {
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                    SpawnParticle();
                    source.PlayOneShot(clip);
                }

                Reset();
            }

            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }
    void SpawnParticle() {
        // Create an instance of the particle system prefab at the position (0, 0, 0)
        // with a rotation of (0, 0, 0)
        
        GameObject particle = Instantiate(ParticlePrefab, transform.position, Quaternion.identity);

        // You can also set the position and rotation of the particle system when you spawn it
        // For example, to spawn the particle system at (1, 2, 3) with a rotation of (45, 0, 0)
    }
}
