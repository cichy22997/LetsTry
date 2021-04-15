using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveRight : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static MoveRight Instance { set; get; }
    public bool moveRight;

    private void Start()
    {
        Instance = this;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        moveRight = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        moveRight = false;
    }
}
