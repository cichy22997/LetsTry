using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public int maxOxygen;
    public int currentOxygen;
    public int lifesAmmount;


    public HealthBar healthBar;
    public OxygenBar oxygenBar;
    private float oxygenTimer;

    public static Player Instance { set; get; }

    private void Start()
    {
        Instance = this;
       
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;

        SetMaxOxygen();
        oxygenTimer = 0f;
    }
    private void FixedUpdate()
    {
        oxygenTimer += Time.fixedDeltaTime;

        if (currentHealth <= 0)
            GameMenager.Instance.OnDeath();

        if (currentOxygen <= 0)
            TakeDamage(1);

    }
    public void TakeDamage(int damage)
    {
        if (LastHitCounter.Instance.lastHitTime > 0.5f)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            DamagedMaterial();
            Invoke("BackToMaterial", 0.1f);
            LastHitCounter.Instance.lastHitTime = 0f;
        }
    }

    private void DamagedMaterial()
    {
        MaterialChange.Instance.ToDamaged();
    }

    private void BackToMaterial()
    {
        switch(MaterialChange.Instance.whichMat)
        {
            case 0:
                MaterialChange.Instance.ToWood();
                break;
            case 1:
                MaterialChange.Instance.ToSteel();
                break;
            case 2:
                MaterialChange.Instance.ToSlime();
                break;
        }
    }

    public void SetMaxOxygen()
    {
        oxygenBar.SetMaxOxygen(maxOxygen);
        currentOxygen = maxOxygen;
    }

    public void TakeOxygenAway()
    {
        if(oxygenTimer> 0.2f)
        {
            currentOxygen--;
            oxygenBar.SetOxygen(currentOxygen);
            oxygenTimer = 0f;
        }
    }
}