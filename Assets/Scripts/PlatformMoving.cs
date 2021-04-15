using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
        private float basePositionX, basePositionY, basePositionZ;
        private float timer, actualTime;
        public bool isStopable, isSticky;
        public bool x, y, z;
        public float delay;
        public float speed = 0.2f;
        public float delta = 0.2f;  //delta is the difference between min y to max y.

    private BoxCollider Collider;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        actualTime = 0f;
        basePositionX = transform.position.x;
        basePositionY = transform.position.y;
        basePositionZ = transform.position.z;


    }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (!PlayerMovement.Instance.stopPlatform && isStopable && timer > delay)
            {
                actualTime += Time.deltaTime;
                PingPong();
            }
            if (timer > delay && !isStopable)
            {
                actualTime += Time.deltaTime;
                PingPong();
            }

        }
        private void PingPong()
        {
            if (x)
            {
                float positionX = basePositionX + Mathf.PingPong(speed * actualTime, delta);
                Vector3 pos = new Vector3(positionX, transform.position.y, transform.position.z);
                transform.position = pos;
            }
            if (y)
            {
                float positionY = basePositionY + Mathf.PingPong(speed * actualTime, delta);
                Vector3 pos = new Vector3(transform.position.x, positionY, transform.position.z);
                transform.position = pos;
            }
            if (z)
            {
                float positionZ = basePositionZ + Mathf.PingPong(speed * actualTime, delta);
                Vector3 pos = new Vector3(transform.position.x, transform.position.y, positionZ);
                transform.position = pos;
            }

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Sphere" || collision.collider.tag == "Cube" || collision.collider.tag == "Star")
            {
                if (isSticky)
                {
                PlayerMovement.Instance.player.transform.parent = transform;
                }
            }
        }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Sphere" || collision.collider.tag == "Cube" || collision.collider.tag == "Star")
        {
            if (isSticky)
            {
                PlayerMovement.Instance.player.transform.parent = null;
            }
        }
    }

}
