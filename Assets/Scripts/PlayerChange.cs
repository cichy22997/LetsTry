using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChange : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject Cube;
    public GameObject Star;


    public Transform target;

    public int whichChar;

    public static PlayerChange Instance;

    void Start()
    {
        Instance = this;

        Sphere.SetActive(true);
        whichChar = 0;
       

        target = Sphere.transform; 
    }

    void FixedUpdate()
    {
        ChangePlayer();
    }

    private void ChangePlayer()
    {
        if (PlayerMovement.Instance.ableToChangeCharacter && PlayerMovement.Instance.changeCharacter)
        {

            switch (whichChar)
            {
                case 0:
                    Cube.SetActive(true);
                    Cube.transform.position = Sphere.transform.position;
                    Sphere.SetActive(false);
                    target = Cube.transform;
                    whichChar = 1;
                    break;
                case 1:
                    whichChar = 2;
                    Star.SetActive(true);
                    Star.transform.position = Cube.transform.position;
                    Cube.SetActive(false);
                    target = Star.transform;
                    break;
                case 2:
                    whichChar = 0;
                    Sphere.SetActive(true);
                    Sphere.transform.position = Star.transform.position;
                    Star.SetActive(false);
                    target = Sphere.transform;
                    break;


            }

            PlayerMovement.Instance.ableToChangeCharacter = false;

        }
       
    }

    public int WhichChar()
    {
        if (whichChar == 0)
            return 0;
        else if (whichChar == 1)
            return 1;
        else if (whichChar == 2)
            return 2;
        return 5;

    }


}
