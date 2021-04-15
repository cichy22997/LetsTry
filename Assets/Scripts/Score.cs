using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int coins;
    public float timer;

    public Text coinText,coinText2;
    public Text Timer,TimerEnd;
    public bool countTime;
    private int maxCoins;
    public int howManyStars;
    public GameObject[] Stars;
    public static Score Instance { set; get; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        coins = 0;
        timer = 0;
        countTime = true;
        maxCoins = FindMaxCoins();
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime)
        {
            timer += Time.deltaTime;
        }

        UpdateScore();
        CountStars();
        AddStars();
    }

    private void UpdateScore()
    {
        coinText.text = coins.ToString();
        Timer.text = timer.ToString("0.0");
        TimerEnd.text = timer.ToString("0.0");
        coinText2.text = coins.ToString() + "/" + maxCoins.ToString();
    }

    private int FindMaxCoins()
    {
        GameObject[] coinsArray = GameObject.FindGameObjectsWithTag("Coin");
        return coinsArray.Length;
    }

    private void CountStars()
    {
        if (coins > 0 && coins < maxCoins / 2)
            howManyStars = 1;
        else if (coins >= maxCoins / 2 && coins < maxCoins)
            howManyStars = 2;
        else if (coins == maxCoins)
            howManyStars = 3;
    }

    private void AddStars()
    {
        switch(howManyStars)
        {
            case 1:
                Stars[0].SetActive(true);
                break;
            case 2:
                Stars[0].SetActive(true);
                Stars[1].SetActive(true);
                break;
            case 3:
                Stars[0].SetActive(true);
                Stars[1].SetActive(true);
                Stars[2].SetActive(true);
                break;
        }
    }

}
