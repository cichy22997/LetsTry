using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveLeft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static MoveLeft Instance { set; get; }
    public bool moveLeft;

    private void Start()
    {
        Instance = this;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        moveLeft = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        moveLeft = false;
    }
}
