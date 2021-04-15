using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
        {
            Score.Instance.coins++;
            Destroy(gameObject);
        }
    }
}
