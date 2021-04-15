using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    private LineRenderer lr;
    public Vector3 grapplePoint, planeVector;
    public LayerMask whatIsGrappleable;
    public Transform centerPoint;
    private float maxDistance = 5f;
    private SpringJoint joint;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    private void FixedUpdate()
    {
        if (MaterialChange.Instance.whichMat == 2)
        {
            if (PlayerMovement.Instance.grapple && PlayerMovement.Instance.ableToGrapple)
            {
                planeVector = FindClosestPlane();

                StartGrapple();
                PlayerMovement.Instance.ableToGrapple = false;
            }
            else if (!PlayerMovement.Instance.grapple)
            {
                StopGrapple();
            }
        }
        else
            StopGrapple();
    }
    private void LateUpdate()
    {
        DrawRope();
    }

    private void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(centerPoint.position, planeVector, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = PlayerMovement.Instance.player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(PlayerMovement.Instance.player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.1f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
    }

    void DrawRope()
    {
        if (!joint) return;

        lr.SetPosition(0, centerPoint.position);
        lr.SetPosition(1, grapplePoint);

    }

    private void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 FindClosestPlane()
    {
        float distanceToClosestPlane = Mathf.Infinity;
        GameObject closestPlane = null;
        GameObject[] allPlanes = GameObject.FindGameObjectsWithTag("Grapple");

        foreach(GameObject currentPlane in allPlanes)
        {
            float distanceToPlane = (currentPlane.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToPlane<distanceToClosestPlane)
            {
                distanceToClosestPlane = distanceToPlane;
                closestPlane = currentPlane;
            }
        }
        Vector3 closestPlaneVector;
        try
        {
            closestPlaneVector = new Vector3(closestPlane.transform.position.x - transform.position.x, closestPlane.transform.position.y - transform.position.y, closestPlane.transform.position.z - transform.position.z);
        }
        catch
        {
            closestPlaneVector = Vector3.zero;
        }

        return closestPlaneVector;
    }
}
