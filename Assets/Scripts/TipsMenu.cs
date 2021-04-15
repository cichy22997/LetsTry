using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsMenu : MonoBehaviour
{
    public Animator anim;
    public Text Hello, Tip;

    [Multiline]
    public string hello, tip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
        {
            Hello.text = hello;
            Tip.text = tip;
            anim.SetTrigger("InfoUp");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
            anim.SetTrigger("InfoDown");
    }
}
