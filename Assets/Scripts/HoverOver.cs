using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverPanal;
    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverPanal.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoverPanal.SetActive(false);
    }
    
}
