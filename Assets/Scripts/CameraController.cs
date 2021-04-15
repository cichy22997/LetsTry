using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    private Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public static CameraController Instance {set; get;}

    private void Start()
    {
        Instance = this;
    }


    void FixedUpdate()
    {
        target = PlayerChange.Instance.target;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
        transform.position = smoothedPosition;


    }
}
