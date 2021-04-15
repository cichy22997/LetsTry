using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public float strength = 10f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
        {
            Player.Instance.TakeDamage(1);
            other.attachedRigidbody.AddForce(Vector3.up * strength, ForceMode.Impulse);
        }
    }
}
