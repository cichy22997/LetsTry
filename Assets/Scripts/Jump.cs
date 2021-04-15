using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static Jump Instance { set; get; }
    public bool jump;

    private void Start()
    {
        Instance = this;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        jump = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        jump = false;
    }
}
