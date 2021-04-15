using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterJumpBar : MonoBehaviour
{

    private Vector3 localScale,baseScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        baseScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = baseScale.x * PlayerMovement.Instance.charger;
        transform.localScale = localScale;
    }
}
