using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Grapple : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static Grapple Instance { set; get; }
    public bool grapple;

    private void Start()
    {
        Instance = this;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        grapple = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        grapple = false;
    }
}
