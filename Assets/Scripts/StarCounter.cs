using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour
{
    public int whichLevel;
    private int howManyStars;
    public GameObject[] Stars;


    private void Update()
    {
        howManyStars = StarsMenager.Instance.AddStar(whichLevel);
        UpdateStars();
    }

    public void UpdateStars()
    {
        try
        {
            switch (howManyStars)
            {

                case 0:
                    foreach (GameObject go in Stars)
                        go.SetActive(false);
                    break;
                case 1:
                    Stars[0].SetActive(true);
                    Stars[1].SetActive(false);
                    Stars[2].SetActive(false);
                    break;
                case 2:
                    Stars[0].SetActive(true);
                    Stars[1].SetActive(true);
                    Stars[2].SetActive(false);
                    break;
                case 3:
                    Stars[0].SetActive(true);
                    Stars[1].SetActive(true);
                    Stars[2].SetActive(true);
                    break;
            }
        }
        catch
        {
            return;
        }
    }


}