using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCounter : MonoBehaviour
{
    public int whichLevel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sphere" || other.tag == "Cube" || other.tag == "Star")
        {
            if (whichLevel > LevelMenager.levelCompleted)
                LevelMenager.levelCompleted = whichLevel;

            if (StarsMenager.Stars[whichLevel - 1] < Score.Instance.howManyStars)
                StarsMenager.Stars[whichLevel - 1] = Score.Instance.howManyStars;

        }
    }
}
