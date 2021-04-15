using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HoldButton : MonoBehaviour, IPointerDownHandler
{
    public static HoldButton Instance { set; get; }
    public bool freeze;

    private void Start()
    {
        Instance = this;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!freeze)
            freeze = true;
        else
            freeze = false;
    }
}
