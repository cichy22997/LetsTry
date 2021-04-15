using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    public float timeToDestroy;
    private float timer;
    private void Start()
    {

        timer = 0f;
    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > timeToDestroy)
        {
            Destroy(gameObject);
        }
    }


}
