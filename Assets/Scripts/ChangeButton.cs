using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ChangeButton : MonoBehaviour, IPointerDownHandler
{
    public static ChangeButton Instance { set; get; }
    public bool change;

    private void Start()
    {
        Instance = this;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        change = true;
    }
}