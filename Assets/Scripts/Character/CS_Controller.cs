using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Controller : MonoBehaviour
{
    [SerializeField]

    private Rigidbody playerBody;
    private Vector3 gravitySpeed;

    public float jumpSpeed = 2000f;
    public float fallSpeed = -100f;

    private int doubleJump = 0;
    private bool noJumpAllowed = false;
    private bool doubleJumpExtraPower = false;

    GameObject go_Collider;
    

    void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        gravitySpeed = new Vector3(0, -fallSpeed, 0);
        go_Collider = GameObject.Find("Collider");
        
    }


    void Update ()
    {
        //Debug.Log(doubleJump);

        if (playerBody.velocity.y < -2) // controls speed going up and coming back down with drag on players rigidbody
        {
            playerBody.drag = 0;
        } else if (playerBody.velocity.y < 8)
        {

            playerBody.drag = 1;
        }


    }

    private void OnTriggerEnter(Collider col) //trigger events 
    {
        switch (col.tag)
        {
            case "Jump Collider": doubleJump = 0; noJumpAllowed = false; playerBody.drag = 0; doubleJumpExtraPower = false; break;

            //case "Drag Collider": playerBody.drag = 5; doubleJumpExtraPower = true; break;
                
        }
    }


    /* void OnCollisionEnter(Collision col) //collision events
     {
         switch (col.gameObject.tag)
         {


         }
     }*/


private void OnGUI()
    {
        if (noJumpAllowed == false) //checks if player can jump again
        {
            if (GUI.Button(new Rect(10, 10, 150, 100), "Jump")) //creates button to jump with
            {

                playerBody.AddForce(new Vector3(0f, jumpSpeed, 0f), ForceMode.Impulse);
                doubleJump++; //adds to double jump counter

               /* if (doubleJumpExtraPower == true) //can he use 
                {
                    playerBody.AddForce(new Vector3(0f, jumpSpeed + 50, 0f), ForceMode.Impulse); // adds power to double jump
                    doubleJumpExtraPower = false;

                }*/


                if (doubleJump >= 2)
                {
                    noJumpAllowed = true;
                }
                else noJumpAllowed = false;


            }
            else
            {
                Physics.gravity = gravitySpeed;

            }




        }
    }

    
}




