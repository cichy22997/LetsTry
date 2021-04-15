using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    public static Respawn Instance { set; get; }
    private Transform respawn;


    public Text lifesAmmount;

    private void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        respawn = FindClosestRespawn();
        LifesUpdate();

    }

    private Transform FindClosestRespawn()
    {
        float distanceToClosestRespawn = Mathf.Infinity;
        GameObject closestRespawn = null;
        GameObject[] allRespawns = GameObject.FindGameObjectsWithTag("Resp");

        foreach (GameObject currentRespawn in allRespawns)
        {
            float distanceToRespawn = (currentRespawn.transform.position - PlayerMovement.Instance.player.transform.position).sqrMagnitude;
            if (distanceToRespawn < distanceToClosestRespawn)
            {
                distanceToClosestRespawn = distanceToRespawn;
                closestRespawn = currentRespawn;
            }
        }
        Transform Respawn = closestRespawn.transform;

        Debug.DrawLine(PlayerMovement.Instance.player.transform.position, Respawn.transform.position);

        return Respawn;
    }

    public void RespawnPlayer()
    {
        PlayerMovement.Instance.player.transform.position = respawn.transform.position;
    }

    private void LifesUpdate()
    {
        lifesAmmount.text = Player.Instance.lifesAmmount.ToString();
    }
}
