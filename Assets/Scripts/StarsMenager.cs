using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsMenager : MonoBehaviour
{
    public static int[] Stars = new int[27];
    public static StarsMenager Instance { set; get; }
    private void Start()
    {
        Instance = this;
    }

    public int AddStar(int _whichLevel)
    {
        return Stars[_whichLevel - 1];
    }
}
