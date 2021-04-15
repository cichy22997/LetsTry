using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody player;

    public float verticalSpeed;

    public bool grounded;
    public float wallJumpSpeed;
    public float turnSpeed;
    public float wallClimbingSpeed;

    public float movementSpeed;
    public float waterJump, charger;
    public float speedInWater;
    public float sandSpeed, baseSandSpeed;

    private bool countCharger;

    public float groundedHeight = 1;

    public float wallRayRightHeight = 0.7f;
    public float wallRayLeftHeight = 0.7f;

    private float globalGravity = -9.81f;
    private float gravityScale = 1f;

    private bool wallRight;
    private bool wallLeft;
    private bool inWater, inSand;
    private bool resetVelocity;
    public bool isAlive;
    public bool stopPlatform;

    public float showVelocityY, showVelocityX;
    public ParticleSystem bubbles;
    public ParticleSystem bubblesJump;
    public static PlayerMovement Instance { set; get; }

    private bool jump, moveHorizontal,ableToJump;
    public bool ableToChangeCharacter, changeCharacter;
    public bool ableToMaterialChange, materialChange;
    public bool grapple, ableToGrapple;
    private bool freeze;
    public Joystick movementJoystick;
    public Joystick functionsJoystick;

    public int whichChar, whichMat;




    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        player = GetComponent<Rigidbody>();
        player.useGravity = false;
        inWater = false;
        inSand = false;
        isAlive = true;
        moveHorizontal = jump = false;
        ableToJump = ableToChangeCharacter = ableToMaterialChange = true;
        freeze = changeCharacter = materialChange = false;
        grapple = false;
        ableToGrapple = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        whichChar = PlayerChange.Instance.whichChar;
        whichMat = MaterialChange.Instance.whichMat;
        if (isAlive)
        {
            Vector3 gravity = globalGravity * gravityScale * Vector3.up * (Time.timeScale / 1f);
            player.AddForce(gravity, ForceMode.Acceleration);

            if (movementJoystick.Vertical > .8f)
                jump = true;
            else
            { 
                jump = false;
                ableToJump = true;
            }

            if (movementJoystick.Horizontal > .2f || movementJoystick.Horizontal < -.2f)
                moveHorizontal = true;
            else
                moveHorizontal = false;


            if (functionsJoystick.Vertical > .9f)
                grapple = true;
            else
            {
                ableToGrapple = true;
                grapple = false;
            }

            if (functionsJoystick.Vertical < -.9f)
                freeze = true;
            else
                freeze = false;

            if (functionsJoystick.Horizontal > .9f)
                changeCharacter = true;
            else
            {
                changeCharacter = false;
                ableToChangeCharacter = true;
            }

            if (functionsJoystick.Horizontal < -.9f)
                materialChange = true;
            else
            {
                ableToMaterialChange = true;
                materialChange = false;
            }
            ChangeSandSpeed();
            ChangeSandSpeedMaterial();
            ChangeWaterSpeed();
            GroundMovement();
            Freeze();
            WaterMovement();
            SandMovement();


        }
        else
        {
            ScaleUp(false, 0.02f, 0.0f);
            player.velocity = Vector3.zero;
        }

        showVelocityY = player.velocity.y;
        showVelocityX = player.velocity.x;

        Debug.DrawRay(transform.position, Vector3.down * groundedHeight);
        Debug.DrawRay(transform.position, Vector3.right * wallRayRightHeight);
        Debug.DrawRay(transform.position, Vector3.left * wallRayLeftHeight);


    }


    private void GroundMovement()
    {

        RaycastHit hitWallRight;
        Ray wallRayRight = new Ray(transform.position, Vector3.right);
        if (Physics.Raycast(wallRayRight, out hitWallRight, wallRayRightHeight))
        {
            if (hitWallRight.collider.tag == "Wall")
                wallRight = true;

        }
        else
            wallRight = false;




        RaycastHit hitWallLeft;
        Ray wallRayLeft = new Ray(transform.position, Vector3.left);
        if (Physics.Raycast(wallRayLeft, out hitWallLeft, wallRayLeftHeight))
        {
            if (hitWallLeft.collider.tag == "Wall")
                wallLeft = true;
        }
        else
            wallLeft = false;




        if (!inWater && !inSand)
        {
            bubbles.Stop();
            gravityScale = 1.0f;

        if (jump && ableToJump)
        {
            if (wallLeft && !grounded)
                player.AddForce(new Vector3(wallJumpSpeed, wallJumpSpeed, 0) * Time.fixedDeltaTime, ForceMode.Impulse);

            if (wallRight && !grounded)
                player.AddForce(new Vector3(-wallJumpSpeed, wallJumpSpeed, 0) * Time.fixedDeltaTime, ForceMode.Impulse);

            if (grounded)
                player.AddForce(new Vector3(0, verticalSpeed, 0), ForceMode.Impulse);
            ableToJump = false;

        }
            RaycastHit hit;
            Ray groundRay = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(groundRay, out hit, groundedHeight))
            {
                if (hit.collider)
                {
                    if(hit.collider.tag != "Water")
                        grounded = true;

                    if (hit.collider.tag == "Ground" && player.velocity.y < -15f)
                        Player.Instance.TakeDamage(1);
                }

            }
            else
                grounded = false;






            if (moveHorizontal)
            {

                player.AddTorque(new Vector3(0, 0, -turnSpeed*2 * movementJoystick.Horizontal), ForceMode.Impulse);

                Vector3 move = Vector3.right * movementJoystick.Horizontal * movementSpeed * Time.fixedDeltaTime;
                player.AddForce(move, ForceMode.Force);
            }
            resetVelocity = true;
        }
    }

    private void WaterMovement()
    {
        if (inWater && !inSand)
        {
            Player.Instance.TakeOxygenAway();
            GameMenager.Instance.OxygenBar.SetActive(true);

            if (MaterialChange.Instance.whichMat == 0)
            {
                ScaleUp(true, 0.01f);
            }

            if (resetVelocity)
            {
                player.velocity = player.velocity * 0.1f;
                player.angularVelocity = player.angularVelocity * 0.1f;
                resetVelocity = false;
            }

            gravityScale = 0.0f;


            if (jump)
            {
                countCharger = true;
            }

            if (countCharger && charger <= 1f)
                charger += Time.deltaTime;

            if (!jump) ////////////////////////////////////////////////////////////
            {
                if (MaterialChange.Instance.whichMat == 0 && player.velocity.y < 3f)
                    player.AddForce(Vector3.up * waterJump * charger * 1.5f * Time.fixedDeltaTime, ForceMode.VelocityChange);
                if (MaterialChange.Instance.whichMat == 1 && player.velocity.y < 3f)
                    player.AddForce(Vector3.up * waterJump * charger * 0.1f * Time.fixedDeltaTime, ForceMode.VelocityChange);
                if (MaterialChange.Instance.whichMat == 2 && player.velocity.y < 3f)
                    player.AddForce(Vector3.up * waterJump * charger * 2f * Time.fixedDeltaTime, ForceMode.VelocityChange);
                bubblesJump.Play();
                charger = 0f;
                countCharger = false;
            }


            if (moveHorizontal)
            {
                player.AddTorque(new Vector3(0, 0, -turnSpeed / 2 * movementJoystick.Horizontal), ForceMode.Impulse);

                Vector3 move = Vector3.right * speedInWater  * movementJoystick.Horizontal * Time.fixedDeltaTime;
                player.AddForce(move, ForceMode.Impulse);
            }

 

            if (!moveHorizontal)
            {
                player.velocity = new Vector3(player.velocity.x * 0.92f, player.velocity.y, 0f);
                player.angularVelocity *= 0.9f;

            }

            if (MaterialChange.Instance.whichMat == 0)
                {
                    if (player.velocity.y > -1f)
                        gravityScale = 0.2f;
                    else
                        gravityScale = 0f;
                }
                if (MaterialChange.Instance.whichMat == 1)
                {
                    if (player.velocity.y > -4f)
                        gravityScale = 0.4f;
                    else
                        gravityScale = 0f;
                }
                if (MaterialChange.Instance.whichMat == 2)
                {
                    if (player.velocity.y > -0.1f)
                        gravityScale = 0.4f;
                    else
                        gravityScale = 0f;
                }


        }
        else
        {
            Player.Instance.SetMaxOxygen();
            GameMenager.Instance.OxygenBar.SetActive(false);
            charger = 0f;
        }    

    }

    private void SandMovement()
    {
        if(!inWater && inSand)
        {
            gravityScale = 0.01f;



            if (moveHorizontal)
            {
                player.AddTorque(new Vector3(0, 0, -turnSpeed * movementJoystick.Horizontal), ForceMode.Force);

                Vector3 move = new Vector3(1 * movementJoystick.Horizontal, 0.75f,0) * sandSpeed * Time.fixedDeltaTime;
                player.AddForce(move, ForceMode.Force);
            }

            if (moveHorizontal)
                resetVelocity = true;
            else
            {
                if (resetVelocity)
                {
                    player.velocity = Vector3.zero;
                    player.angularVelocity = Vector3.zero;
                    resetVelocity = false;
                }
            }
        }

    }
    private void Freeze()
    {
        if (freeze)
        {
            player.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            stopPlatform = true;
        }
        else
        {
            player.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            stopPlatform = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            inWater = true;
            bubbles.Play();
        }
        if (other.tag == "Sand")
        {
            inSand = true;
            player.velocity = player.velocity/10f;
            player.angularVelocity = player.angularVelocity/10f;
        }
        if (other.tag == "Flag")
            GameMenager.Instance.EndLevel();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Magnet" && MaterialChange.Instance.whichMat == 1)
            player.AddForce(Vector3.up, ForceMode.Impulse);
        if (MaterialChange.Instance.whichMat == 0)
        {
            if (other.tag == "RainArea")
                ScaleUp(true, 0.01f);
            if (other.tag == "HeatArea")
                ScaleUp(false, 0.01f, 0.4f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
            inWater = false;
        if (other.tag == "Sand")
            inSand = false;
    }


    public void ScaleUp(bool whichDirection, float scaleSpeed)
    {
        if (whichDirection == true)
        {

            if (player.transform.localScale.x < 1)
            {
                player.transform.localScale += new Vector3(1, 1, 0) * scaleSpeed;
                groundedHeight += scaleSpeed;
                wallRayLeftHeight += scaleSpeed/2;
                wallRayRightHeight += scaleSpeed/2;
            }

        }
        else
        {

            if (player.transform.localScale.x > 0.4f)
            {
                player.transform.localScale -= new Vector3(1, 1, 0) * scaleSpeed;
                groundedHeight -= scaleSpeed;
                wallRayLeftHeight -= scaleSpeed/2;
                wallRayRightHeight -= scaleSpeed/2;
            }

        }

    }
    public void ScaleUp(bool whichDirection, float scaleSpeed, float size)
    {

        if (whichDirection == true)
        {

            if (player.transform.localScale.x < 1)
            {
                player.transform.localScale += new Vector3(1, 1, 0) * scaleSpeed;
                groundedHeight += scaleSpeed;
                wallRayLeftHeight += scaleSpeed/2;
                wallRayRightHeight += scaleSpeed/2;
            }

        }
        else
        {

            if (player.transform.localScale.x > size)
            {
                player.transform.localScale -= new Vector3(1, 1, 0) * scaleSpeed;
                groundedHeight -= scaleSpeed;
                wallRayLeftHeight -= scaleSpeed/2;
                wallRayRightHeight -= scaleSpeed/2;
            }

        }

    }

    private void ChangeWaterSpeed()
    {
        switch (PlayerChange.Instance.whichChar)
        {
            case 0:
                speedInWater = 0.0001f;
                break;
            case 1:
                speedInWater = .5f;
                break;
            case 2:
                speedInWater = 1f;
                break;
        }
    }

    private void ChangeSandSpeed()
    {
        switch (PlayerChange.Instance.whichChar)
        {
            case 0:
                baseSandSpeed = 0.0001f;
                break;
            case 1:
                baseSandSpeed = 10f;
                break;
            case 2:
                baseSandSpeed = 15f;
                break;
        }
    }

    private void ChangeSandSpeedMaterial()
    {
        switch (MaterialChange.Instance.whichMat)
        {
            case 0:
                sandSpeed = baseSandSpeed;
                break;
            case 1:
               sandSpeed = baseSandSpeed / 2;
                break;
            case 2:
                sandSpeed = baseSandSpeed * 1.5f;
                break;
        }
    }


}
  

