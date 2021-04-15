using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelMenager : MonoBehaviour
{
    public static int levelCompleted;
    public int showCompletedLevel;
    public Image[] woodLevels, steelLevels, slimeLevels;
    public static bool steelIsAvailable, slimeIsAvailable;

    private void FixedUpdate()
    {
        showCompletedLevel = levelCompleted;
        UnlockLevel(26);/////////////////////
    }

    private void UnlockLevel(int _completedLevel)
    {
        if(_completedLevel>= 1 && _completedLevel < 9)
        {
            for (int i = 0; i < _completedLevel; i++)
            woodLevels[i].enabled = false;
        }

        if (_completedLevel >= 9 && _completedLevel < 18)
        {
            steelIsAvailable = true;
            foreach (Image image in woodLevels)
                image.enabled = false;

            for (int i = 0; i < _completedLevel-8; i++)
                steelLevels[i].enabled = false;
        }
        if (_completedLevel >= 18)
        {
            steelIsAvailable = true;
            slimeIsAvailable = true;
            foreach (Image image in woodLevels)
                image.enabled = false;
            foreach (Image image in steelLevels)
                image.enabled = false;
            for (int i = 0; i < _completedLevel - 17; i++)          
                slimeLevels[i].enabled = false;
        }
    }



}
