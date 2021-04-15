using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroy : MonoBehaviour
{
    public GameObject WallDestroyed;
    private GameObject newWall;
    private Vector3 scale;
    // Start is called before the first frame update
    private void Start()
    {
        scale = transform.localScale;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star" )
        {
            if (MaterialChange.Instance.whichMat == 1 && (Mathf.Abs(PlayerMovement.Instance.showVelocityY) > 6f || Mathf.Abs(PlayerMovement.Instance.showVelocityX) > 6f))
            {
                newWall = Instantiate(WallDestroyed, transform.position, transform.rotation);
                newWall.transform.localScale = scale;
                Destroy(gameObject);
            }
        }
    }
}
