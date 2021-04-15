using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{

    public Material wood;
    public Material steel;
    public Material slime;
    public Material damaged;

    public int whichMat;

    public bool sticky;

    public Renderer[] rend;

    public static MaterialChange Instance;

    public PhysicMaterial stickyMaterial;
    public PhysicMaterial normalMaterial;


    public ParticleSystem slimeEffect;

    public Collider SphereCollider;
    public Collider CubeCollider;
    public GameObject StarCollider;

    void Start()
    {
        Instance = this;

        whichMat = 0;

        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].enabled = true;
            rend[i].sharedMaterial = wood;
        }

    }


    void FixedUpdate()
    {
        ChangeMaterial();
        UpdateMass();
        MakeItSticky();
    }


    private void ChangeMaterial()
    {
        if (PlayerMovement.Instance.ableToMaterialChange && PlayerMovement.Instance.materialChange)
        {
            switch (whichMat)
            {
                case 0:
                    if (LevelMenager.steelIsAvailable)
                    {
                        whichMat = 1;
                        ToSteel();
                    }
                    break;
                case 1:
                    if (LevelMenager.slimeIsAvailable)
                    {
                        whichMat = 2;
                        ToSlime();
                    }
                    else
                    {
                        whichMat = 0;
                        ToWood();
                    }
                    break;
                case 2:
                    whichMat = 0;
                    ToWood();
                    break;
            }
            PlayerMovement.Instance.ableToMaterialChange = false;
        }
    }

    private void UpdateMass()
    {

        switch (whichMat)
        {
            case 0:
                PlayerMovement.Instance.player.mass = 1f;
                break;
            case 1:
                PlayerMovement.Instance.player.mass = 2f;
                break;
            case 2:
                PlayerMovement.Instance.player.mass = 0.8f;
                break;
        }

    }



    private void MakeItSticky()
    {
        if (sticky)
        {
            SphereCollider.material = stickyMaterial;
            CubeCollider.material = stickyMaterial;
            Collider[] starColliders = StarCollider.GetComponents<Collider>();
            for (int i = 0; i < starColliders.Length; i++)
            {
                starColliders[i].material = stickyMaterial;
            }
        }
        else
        {
            SphereCollider.material = normalMaterial;
            CubeCollider.material = normalMaterial;
            Collider[] starColliders = StarCollider.GetComponents<Collider>();
            for (int i = 0; i < starColliders.Length; i++)
            {
                starColliders[i].material = normalMaterial;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (sticky == true)
        {
            ContactPoint[] contacts = new ContactPoint[10];
            int numContacts = collision.GetContacts(contacts);
            for (int i = 0; i < numContacts; i++)
            {
                slimeEffect.transform.position = contacts[i].point;
            }

            slimeEffect.Play();
        }

    }

    public void ToWood()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].sharedMaterial = wood;
        }

        sticky = false;
    }

    public void ToSteel()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].sharedMaterial = steel;
        }

        sticky = false;
    }

    public void ToSlime()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].sharedMaterial = slime;
        }

        sticky = true;
    }
    public void ToDamaged()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].sharedMaterial = damaged;
        }

    }
}
