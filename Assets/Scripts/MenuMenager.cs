using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMenager : MonoBehaviour
{
    private int whichMap;

    public GameObject Logo;
    public GameObject StartButton;
    public GameObject OptionsButton;
    public GameObject ExitButton;
    public GameObject WoodPanel;
    public GameObject SteelPanel;
    public GameObject SlimePanel;
    public GameObject LeftArrow;
    public GameObject RightArrow;
    public GameObject OptionsPanel;

    public Animator cameraAnim;

    private void Awake()
    {
        WoodPanel.SetActive(false);
        SteelPanel.SetActive(false);
        SlimePanel.SetActive(false);
        whichMap = 1;
    }
    public void OnStart()
    {
        switch (whichMap)
        {
            case 1:
                WoodPanel.SetActive(true);
                break;
            case 2:
                SteelPanel.SetActive(true);
                break;
            case 3:
                SlimePanel.SetActive(true);
                break;
        }
        RightArrow.SetActive(true);
        LeftArrow.SetActive(true);
        Logo.SetActive(false);
        StartButton.SetActive(false);
        OptionsButton.SetActive(false);
        ExitButton.SetActive(false);
    }

    public void OnOptions()
    {
        Logo.SetActive(false);
        StartButton.SetActive(false);
        OptionsButton.SetActive(false);
        ExitButton.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnBackButton()
    {
        RightArrow.SetActive(false);
        LeftArrow.SetActive(false);
        Logo.SetActive(true);
        StartButton.SetActive(true);
        OptionsButton.SetActive(true);
        ExitButton.SetActive(true);
        OptionsPanel.SetActive(false);
        switch (whichMap)
        {
            case 1:
                WoodPanel.SetActive(false);
                break;
            case 2:
                SteelPanel.SetActive(false);
                break;
            case 3:
                SlimePanel.SetActive(false);
                break;
        }
    }

    public void ArrowRight()
    {
        switch (whichMap)
        {
            case 1:
                whichMap = 2;
                WoodPanel.SetActive(false);
                SteelPanel.SetActive(true);
                cameraAnim.SetTrigger("WoodToSteel");
                break;
            case 2:
                whichMap = 3;
                SteelPanel.SetActive(false);
                SlimePanel.SetActive(true);
                cameraAnim.SetTrigger("SteelToSlime");
                break;
            case 3:
                whichMap = 1;
                SlimePanel.SetActive(false);
                WoodPanel.SetActive(true);
                cameraAnim.SetTrigger("SlimeToWood");
                break;
        }
    }

    public void ArrowLeft()
    {
        switch (whichMap)
        {
            case 1:
                whichMap = 3;
                WoodPanel.SetActive(false);
                SlimePanel.SetActive(true);
                cameraAnim.SetTrigger("WoodToSlime");
                break;
            case 2:
                whichMap = 1;
                SteelPanel.SetActive(false);
                WoodPanel.SetActive(true);
                cameraAnim.SetTrigger("SteelToWood");
                break;
            case 3:
                whichMap = 2;
                SlimePanel.SetActive(false);
                SteelPanel.SetActive(true);
                cameraAnim.SetTrigger("SlimeToSteel");
                break;
        }
    }

    public void LoadMap1()
    {
        switch (whichMap)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("WoodMap1");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SteelMap1");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SlimeMap1");
                break;
        }
    }

    public void LoadMap2()
    {
        switch (whichMap)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("WoodMap2");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SteelMap2");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SlimeMap2");
                break;
        }
    }

    public void LoadMap3()
    {
        switch (whichMap)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("WoodMap3");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SteelMap3");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SlimeMap3");
                break;
        }
    }

    public void LoadMap4()
    {
        switch (whichMap)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("WoodMap4");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SteelMap4");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SlimeMap4");
                break;
        }
    }

    public void LoadMap5()
    {
        switch (whichMap)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("WoodMap5");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SteelMap5");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SlimeMap5");
                break;
        }
    }

    public void LoadMap6()
    {
        switch (whichMap)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("WoodMap6");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SteelMap6");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SlimeMap6");
                break;
        }
    }

    public void LoadMap7()
    {
        switch (whichMap)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("WoodMap7");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SteelMap7");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SlimeMap7");
                break;
        }
    }

    public void LoadMap8()
    {
        switch (whichMap)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("WoodMap8");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SteelMap8");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SlimeMap8");
                break;
        }
    }

    public void LoadMap9()
    {
        switch (whichMap)
        {
            case 1:
                UnityEngine.SceneManagement.SceneManager.LoadScene("WoodMap9");
                break;
            case 2:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SteelMap9");
                break;
            case 3:
                UnityEngine.SceneManagement.SceneManager.LoadScene("SlimeMap9");
                break;
        }
    }

}
