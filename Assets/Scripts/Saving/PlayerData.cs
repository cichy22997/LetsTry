using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int coins;
    public int level;
    public int lifes;

    public PlayerData (PlayerProgress player)
    {
        coins = player.coins;
        level = player.level;
        lifes = player.lifes;
    }
}
