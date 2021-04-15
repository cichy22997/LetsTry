using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{
    public int coins;
    public int level;
    public int lifes;


    public static int coinsBuffer;
    public static int levelBuffer;
    public static int lifesBuffer;

    public static PlayerProgress Instance { set; get; }

    void Start()
    {
        Instance = this;
    }

public void AddCoins()
    {
        coins += Score.Instance.coins;
    }
    public void AddLevel()
    {
        level++;
    }    

    public void ProgressUpdate()
    {
        coins = coinsBuffer;
        level = levelBuffer;
    }
    public void SaveProgress()
    {
        Saving.SaveProgress(this);
    }
    public void LoadProgress()
    {

        string path = Application.persistentDataPath + "/player.dont";
        if (File.Exists(path))
        {
            PlayerData data = Saving.LoadProgress();
            coinsBuffer = data.coins;
            levelBuffer = data.level;
          


        }
        else
        {
            SaveProgress();
        }


        ProgressUpdate();
    }
}
