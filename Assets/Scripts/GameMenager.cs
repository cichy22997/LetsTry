using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    public Text timeText, coinText;
    public Animator menuAnim;
    public Animator flag, EndLevelMenu;
    public static GameMenager Instance { set; get; }

    public GameObject OxygenBar;
    public GameObject PausePanel;

    private void Start()
    {
        Instance = this;
        PausePanel.SetActive(false);
        OxygenBar.SetActive(false);
    }
    private void FixedUpdate()
    {
        timeText.text = Score.Instance.timer.ToString("0.0");
        coinText.text = Score.Instance.coins.ToString();
    }
    public void OnDeath()
    {
        PlayerMovement.Instance.isAlive = false;

        if (Player.Instance.lifesAmmount > 1)
        {
            Player.Instance.currentHealth = Player.Instance.maxHealth;
            Invoke("RespawnPlayer", 1.5f);
        }
        else if(Player.Instance.lifesAmmount == 1)
        {
            Player.Instance.lifesAmmount = 0;
            Score.Instance.countTime = false;
            menuAnim.SetTrigger("OnDeath");
        }

    }

    private void RespawnPlayer()
    {
        Player.Instance.healthBar.SetMaxHealth(Player.Instance.maxHealth);
        Respawn.Instance.RespawnPlayer();
        Player.Instance.lifesAmmount--;
        PlayerMovement.Instance.isAlive = true;
        PlayerMovement.Instance.player.transform.localScale = Vector3.one;
        PlayerMovement.Instance.wallRayLeftHeight = PlayerMovement.Instance.wallRayRightHeight = 0.7f;
        PlayerMovement.Instance.groundedHeight = 1f;
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public  void OnPause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ContinueFromPause()
    {
        Time.timeScale = 1.0f;
        PausePanel.SetActive(false);
    }

    public void OnMenuButton()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void EndLevel()
    {
        flag.SetTrigger("FlagUp");
        EndLevelMenu.SetTrigger("EndLevel");
        PlayerMovement.Instance.isAlive = false;
        Score.Instance.countTime = false;
    }

    public void OnNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
    }
}
