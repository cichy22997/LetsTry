using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastHitCounter : MonoBehaviour
{
    public static LastHitCounter Instance { get; set; }
    public float lastHitTime;

    private void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        lastHitTime += Time.fixedDeltaTime;
    }

    public void OnClick()
    {
        lastHitTime = 0;
    }
}
