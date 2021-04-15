using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float strength;

    private void OnTriggerStay(Collider other)
    {
        if (transform.rotation == Quaternion.Euler(0f, 0f, 0f))
        {
            //Up
            if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
            {


                if (MaterialChange.Instance.whichMat == 0)
                    other.attachedRigidbody.AddForce(Vector3.up * strength * Time.deltaTime, ForceMode.Impulse);
                else if (MaterialChange.Instance.whichMat == 1)
                    other.attachedRigidbody.AddForce(Vector3.up * strength * 0.2f * Time.deltaTime, ForceMode.Impulse);
                else if (MaterialChange.Instance.whichMat == 2)
                    other.attachedRigidbody.AddForce(Vector3.up * strength * 1.2f * Time.deltaTime, ForceMode.Impulse);
                else
                    other.attachedRigidbody.AddForce(Vector3.up * strength * Time.deltaTime, ForceMode.Impulse);
            }
            else
                other.attachedRigidbody.AddForce(Vector3.up * strength * 0.7f * Time.deltaTime, ForceMode.Impulse);
        }
        //Right
        if (transform.rotation == Quaternion.Euler(0f, 0f, -90f))
        {
            if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
            {


                if (MaterialChange.Instance.whichMat == 0)
                    other.attachedRigidbody.AddForce(Vector3.right * strength * Time.deltaTime, ForceMode.Impulse);
                else if (MaterialChange.Instance.whichMat == 1)
                    other.attachedRigidbody.AddForce(Vector3.right * strength * 0.2f * Time.deltaTime, ForceMode.Impulse);
                else if (MaterialChange.Instance.whichMat == 2)
                    other.attachedRigidbody.AddForce(Vector3.right * strength * 1.2f * Time.deltaTime, ForceMode.Impulse);
                else
                    other.attachedRigidbody.AddForce(Vector3.right * strength * Time.deltaTime, ForceMode.Impulse);
            }
            else
                other.attachedRigidbody.AddForce(Vector3.right * strength * 0.7f * Time.deltaTime, ForceMode.Impulse);
        }
        //Left
        if (transform.rotation == Quaternion.Euler(0f, 0f, 90f))
        {
            if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
            {


                if (MaterialChange.Instance.whichMat == 0)
                    other.attachedRigidbody.AddForce(Vector3.left * strength * Time.deltaTime, ForceMode.Impulse);
                else if (MaterialChange.Instance.whichMat == 1)
                    other.attachedRigidbody.AddForce(Vector3.left * strength * 0.2f * Time.deltaTime, ForceMode.Impulse);
                else if (MaterialChange.Instance.whichMat == 2)
                    other.attachedRigidbody.AddForce(Vector3.left * strength * 1.2f * Time.deltaTime, ForceMode.Impulse);
                else
                    other.attachedRigidbody.AddForce(Vector3.left * strength * Time.deltaTime, ForceMode.Impulse);
            }
            else
                other.attachedRigidbody.AddForce(Vector3.left * strength * 0.7f * Time.deltaTime, ForceMode.Impulse);
        }
        //Down
        if (transform.rotation == Quaternion.Euler(0f, 0f, 180f) || transform.rotation == Quaternion.Euler(0f, 0f, -180f))
        {
            if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
            {


                if (MaterialChange.Instance.whichMat == 0)
                    other.attachedRigidbody.AddForce(Vector3.down * strength * Time.deltaTime, ForceMode.Impulse);
                else if (MaterialChange.Instance.whichMat == 1)
                    other.attachedRigidbody.AddForce(Vector3.down * strength * 0.2f * Time.deltaTime, ForceMode.Impulse);
                else if (MaterialChange.Instance.whichMat == 2)
                    other.attachedRigidbody.AddForce(Vector3.down * strength * 1.2f * Time.deltaTime, ForceMode.Impulse);
                else
                    other.attachedRigidbody.AddForce(Vector3.down * strength * Time.deltaTime, ForceMode.Impulse);
            }
            else
                other.attachedRigidbody.AddForce(Vector3.down * strength * 0.7f * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
