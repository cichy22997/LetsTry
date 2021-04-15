using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 rotationSpeed;
    private float basePosition;
    public float speed = 0.2f;
    public float delta = 0.2f;  //delta is the difference between min y to max y.

    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = new Vector3(0, 2, 0);
        basePosition = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed);

        float positionY = basePosition + Mathf.PingPong(speed * Time.time, delta);
        Vector3 pos = new Vector3(transform.position.x, positionY, transform.position.z);
        transform.position = pos;


    }
}
