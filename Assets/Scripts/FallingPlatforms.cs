using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatforms : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
        {
            Invoke("AddFalling", 1.5f);
        }
    }

    private void AddFalling()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }
}

